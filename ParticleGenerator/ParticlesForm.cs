using SharpQuill;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;
using static System.Net.WebRequestMethods;

namespace ParticleGenerator
{
  public partial class ParticlesForm : Form
  {
    private SteadyParticles? steadyParticles;//making nullable
    private string readPath;
    private Sequence sequence;

    public ParticlesForm()
    {
      InitializeComponent();
      //showing allowed range for certain values for uesr
      gridScaleRangeAllowText.Text += xChoice.Minimum + " to " + xChoice.Maximum;
      drawDupRangeAllowText.Text += objChoice.Minimum + " to " + objChoice.Maximum;
      timeAllowRangeText.Text += secondsChoice.Minimum + " to " + secondsChoice.Maximum;
      offsetDupsAllowRangeText.Text += dupChoice.Minimum + " to " + dupChoice.Maximum;
  }

    //this is so that you can remove any errors after changing values
    private void ErrorRemovingChangeHandler(object sender, EventArgs e)
    {
      warningText.Visible = false;//this is lazy bc you could have more than one error but... .eh
      //may want to change this from a list later!!
      List<ErrorProvider> errorProviders = new List<ErrorProvider>
      {
        //quillErrorProvider; //not including this bc gets caught and handled via QuillSelect
        
        //saveFileErrorProvider,//this often comes up when you decide to cancel saving, so not needed
        noPaintLayersErrorProvider,
        noLayerChosenErrorProvider,
        noStrokesErrorProvider,
        noProjectChosenErrorProvider
      };
      Control control = sender as Control;
      if (control != null)
      {
        foreach (ErrorProvider errorProvider in errorProviders)
        {
          if (errorProvider.GetError(control) != "")
          {
            errorProvider.SetError(control, String.Empty);
          }
        }
      }
    }


    //
    private void genParts_click(object sender, EventArgs e)
    {
      //clear the projectCreatedText
      //Shouldn't be needed as shouldn't be that slow-- but may be if high values or high vertex layers are used
      projectCreatedText.Text = "Working on it...";
      //hide the warning text 
      warningText.Visible = false;
      
      int numObjs = (int)objChoice.Value;//have a dropdown/
      int numDups = (int)dupChoice.Value;//have a dropdown/
      LayerPaint startLayer;
      //sequence from file dialog, write path from save dialog-- see blendshape starter for ideas
     
      //first make sure a Quill project is selected
      if(readPath == null || readPath ==String.Empty || readPath == "" || sequence == null )
      {
        projectCreatedText.Text = "";
        warningText.Visible = true;
        noProjectChosenErrorProvider.SetError(selectQuillButton, "You must select a valid Quill project folder containing at least one paint layer");
        return;
      }
      else//then check that a paint layer is selected from the dropdown
      {
        noProjectChosenErrorProvider.SetError(selectQuillButton, String.Empty);
        string startLayerName = layersComboBox.Text;
        //a double check that the project contains paint layers
        if(layersComboBox.Items.Count == 0)
        {
          projectCreatedText.Text = "";
          noPaintLayersErrorProvider.SetError(selectQuillButton, String.Empty);
          warningText.Visible = true;
          return;
        }
        else
        {
          noPaintLayersErrorProvider.SetError(selectQuillButton, String.Empty);
          //check that a layer is selected (this is in the case that there are several paint layers to choose from)
          if (startLayerName == "" || startLayerName == null)
          {
            projectCreatedText.Text = "";
            noLayerChosenErrorProvider.SetError(layersComboBox, "You must select a paint layer from the dropdown");
            warningText.Visible = true;
            return; //to stop rest of function
          }
          else//then set the start layer
          {
            startLayer = (LayerPaint)sequence.RootLayer.FindChild(startLayerName);
            noLayerChosenErrorProvider.SetError(layersComboBox, String.Empty);
            //not really sure why this could be null-- could be a lag issue? may need to look into if it happens often
            if (startLayer == null)
            {
              projectCreatedText.Text = "";
              noLayerChosenErrorProvider.SetError(layersComboBox, "Chosen layer could not be found. Please try saving and closing out Quill, if open, or closing and restarting this program.");
              return;
            }

            //check that startLayer contains strokes
            if (startLayer.Drawings[0].Data.Strokes.Count == 0)
            {
              projectCreatedText.Text = "";
              warningText.Visible = true;
              noStrokesErrorProvider.SetError(layersComboBox, "No strokes found in the layer (or first frame of the layer). Please inspect your Quill project file and try again.");
              return;
            }
            else
            {
              noStrokesErrorProvider.SetError(layersComboBox, String.Empty);
            }
          }
        } 
      }
      //set writePath to empty to start
      string writePath = "";
      //get writepath from the saveas dialog-- see blendshape starters for example
      SaveFileDialog sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        writePath = Path.GetFullPath(sfd.FileName);
      }
      else
      {
        projectCreatedText.Text = "";
        //break out of function didn't save
        return;
      }
    
      //get your grid size factors from the dropdowns
      float yFact = (float)yChoice.Value;
      float zFact = (float)zChoice.Value;
      float xFact = (float)xChoice.Value;

      //get value from form and then multiplay by 12600 (done later in code-- in steady particles)
      float loopTime = (float)secondsChoice.Value;

      //whether or not to randomly rotate as well as reposition the particles
      bool rotate = checkBox_rotate.Checked;

      // Initialize the SteadyParticle instance
      steadyParticles = new SteadyParticles(numObjs, numDups, sequence, startLayer, xFact, yFact, zFact, loopTime, rotate);
      steadyParticles.GenerateSteadyParticles();
      QuillSequenceWriter.Write(sequence, writePath);
      projectCreatedText.Text = "Project successfully created at " + writePath;

    }

    //Selects a Quill project file, checks to make sure it's actually is a Quill project
    //If it's valid, populates dropdown-- but gives an error if contains no paint layers
    private void selectQuillButton_Click(object sender, EventArgs e)
    {
      readPathChoice.Text = "Loading and analyzing file...";
      //clear out items in current dropdown list and reset text
      layersComboBox.Items.Clear();
      layersComboBox.Text = String.Empty;

      //see if error messages on this, and reset if so
      ErrorRemovingChangeHandler(sender, e);


      if (chooseProjectFileDialog.ShowDialog() == DialogResult.OK)
      {
        string selectedFolder = chooseProjectFileDialog.SelectedPath;
        readPathChoice.Text = selectedFolder;
        readPath = selectedFolder;
        sequence = QuillSequenceReader.Read(readPath);
        if(sequence==null){
          quillErrorProvider.SetError(readPathChoice, "Not a valid Quill project folder. Should be a folder containing Quill.json, State,json, Quill.qbin");
        }
        else
        {
          quillErrorProvider.SetError(readPathChoice, String.Empty);
          populateLayerDropdown(sequence.RootLayer, layersComboBox);
          if(layersComboBox.Items.Count == 0)
          {
            noPaintLayersErrorProvider.SetError(readPathChoice, "The project you chose does not contain any paint layers");
          }
          else
          {
            noPaintLayersErrorProvider.SetError(readPathChoice, String.Empty);
          }
        }
      }     
    }

    //recursive method, goes through all layers of selected project
    // if a group layer, keeps recursively calling, if paint layer, adds to comboxbox
    private void populateLayerDropdown(Layer layer, ComboBox dropdown)
    {
      if(layer.Type.ToString() == "Group")
      {
        foreach(Layer child in ((LayerGroup)layer).Children)
        {
          populateLayerDropdown(child, dropdown);
        }
      }
      else if(layer.Type.ToString() == "Paint")
      {
        dropdown.Items.Add(layer.Name);
      }
    }



    //Go to the README/instructions doc (just a Google doc)
    private void readMeLink_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      readMeLink.LinkVisited = true;

      // Navigate to Google doc
      string url = "https://docs.google.com/document/d/1ZPfIfOvj81pkl_Q7Olp57M56XbjWi44Dg2UFQq3_-FI/edit?usp=sharing";

      //Should be able to just do the following, but caused errors and wouldn't work on my system. So doing the long way:
      ////System.Diagnostics.Process.Start(url);
      ProcessStartInfo psi = new ProcessStartInfo
      {
        FileName = "cmd",
        RedirectStandardInput = true,
        UseShellExecute = false,
        CreateNoWindow = true
      };

      Process process = new Process { StartInfo = psi };
      process.Start();

      using (StreamWriter sw = process.StandardInput)
      {
        if (sw.BaseStream.CanWrite)
        {
          sw.WriteLine("start " + url);
        }
      }
      process.WaitForExit();
      process.Close();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
