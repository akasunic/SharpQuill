using SharpQuill;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;

namespace ParticleGenerator
{
  public partial class Form1 : Form
  {
    private SteadyParticles? steadyParticles;//making nullable
    private string readPath;
    private Sequence sequence;

    public Form1()
    {
      InitializeComponent();
    }

    private void genParts_click(object sender, EventArgs e)
    {

    


      //THE FOLLOWING CHANGED TO FORM CHOICE!!!
      int numObjs = (int)objChoice.Value;//have a dropdown/forced numerical entry-- use tooltips
      int numDups = (int)dupChoice.Value;//have a dropdown/forced numerical entry-- use tooltips

      //sequence from file dialog, write path from save dialog-- see blendshape starter for ideas
      //readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Grid-test";

      //Sequence sequence = QuillSequenceReader.Read(readPath);
      //string writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\randomizedParticles";
      //use dropdown to choose layer-- see blendshape app for ideas
      //get start layer

      if(readPath == null || readPath ==String.Empty || readPath == "")
      {
        noProjectChosenErrorProvider.SetError(selectQuillButton, "You must select a Quill project folder");
        return;
      }
      else
      {
        noProjectChosenErrorProvider.SetError(selectQuillButton, String.Empty);
      }
      string startLayerName = layersComboBox.Text;
      if(startLayerName == "" || startLayerName == null)
      {
        noLayerChosenErrorProvider.SetError(layersComboBox, "You must select a paint layer from the dropdown");
        return; //to stop rest of function
      }
      else
      {
        noLayerChosenErrorProvider.SetError(layersComboBox, String.Empty);
      }
      LayerPaint startLayer = (LayerPaint)sequence.RootLayer.FindChild(startLayerName);

      //check that startLayer contains strokes
      if (startLayer.Drawings[0].Data.Strokes.Count == 0)
      {
        noStrokesErrorProvider.SetError(layersComboBox, "No strokes found in the layer (or first frame of the layer). Please inspect your Quill project file and try again.");
        return;
      }
      else
      {
        noStrokesErrorProvider.SetError(layersComboBox, String.Empty);
      }


      string writePath = "";
      //get writepath from the saveas dialog-- see blendshape starters for example
      SaveFileDialog sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        writePath = Path.GetFullPath(sfd.FileName);
        //null out error provider
        saveFileErrorProvider.SetError(genSteadyParts, String.Empty);

      }
      else
      {
        saveFileErrorProvider.SetError(genSteadyParts, "Issue with saving the project. Please try again or reach out via Discord/Google doc (above).");
        return;
      }

      float yFact = (float)yChoice.Value;
      float zFact = (float)zChoice.Value;
      float xFact = (float)xChoice.Value;

      //get value from form and then multiplay by 12600
      float loopTime = (float)secondsChoice.Value;

      bool rotate = checkBox_rotate.Checked;


      // Initialize the ParticleGenerator
      //particleGenerator = new ParticleGenerator();
      //public SteadyParticles(int numObjs, int numDups, Sequence sequence, LayerPaint startLayer, LayerPaint targetLayer, int xFact, int yFact, int zFact)
      steadyParticles = new SteadyParticles(numObjs, numDups, sequence, startLayer, xFact, yFact, zFact, loopTime, rotate);
      steadyParticles.GenerateSteadyParticles();
      QuillSequenceWriter.Write(sequence, writePath);
    }

  
    private void selectQuillButton_Click(object sender, EventArgs e)
    {
      //clear out items in current dropdown list and reset text
      layersComboBox.Items.Clear();
      layersComboBox.Text = String.Empty;
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

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void numericUpDown3_ValueChanged(object sender, EventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void label8_Click(object sender, EventArgs e)
    {

    }

    private void label11_Click(object sender, EventArgs e)
    {

    }

    private void readMeLink_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      readMeLink.LinkVisited = true;

      // Navigate to Google doc
      System.Diagnostics.Process.Start("https://docs.google.com/document/d/1ZPfIfOvj81pkl_Q7Olp57M56XbjWi44Dg2UFQq3_-FI/edit?usp=sharing");
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void numericUpDown2_ValueChanged(object sender, EventArgs e)
    {

    }

    private void label12_Click(object sender, EventArgs e)
    {

    }

    private void numericUpDown6_ValueChanged(object sender, EventArgs e)
    {

    }

    private void label13_Click(object sender, EventArgs e)
    {

    }

    
  }
}
