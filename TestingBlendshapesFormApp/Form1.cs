using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Diagnostics;
using SharpQuill;

namespace TestingBlendshapesFormApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private Sequence? sequence; //this syntax declares as nullable (so can set sequence to null to reset form)

    //array of all the 50 blendshapes names needed for Unity Live Face Capture. Can adjust names as needed
    private string[] blendshapeNames =
    {
      "browInnerUp",
      "browDownLeft",
      "browDownRight",
      "browOuterUpLeft",
      "browOuterUpRight",
      "eyeLookUpLeft",
      "eyeLookUpRight",
      "eyeLookDownLeft",
      "eyeLookDownRight",
      "eyeLookInLeft",
      "eyeLookInRight",
      "eyeLookOutLeft",
      "eyeLookOutRight",
      "eyeBlinkLeft",
      "eyeBlinkRight",
      "eyeSquintRight",
      "eyeSquintLeft",
      "eyeWideLeft",
      "eyeWideRight",
      "cheekPuff",
      "cheekSquintLeft",
      "cheekSquintRight",
      "noseSneerLeft",
      "noseSneerRight",
      "jawOpen",
      "jawForward",
      "jawLeft",
      "jawRight",
      "mouthFunnel",
      "mouthPucker",
      "mouthLeft",
      "mouthRight",
      "mouthRollUpper",
      "mouthRollLower",
      "mouthShrugUpper",
      "mouthShrugLower",
      "mouthSmileLeft",
      "mouthSmileRight",
      "mouthFrownLeft",
      "mouthFrownRight",
      "mouthDimpleLeft",
      "mouthDimpleRight",
      "mouthUpperUpLeft",
      "mouthUpperUpRight",
      "mouthLowerDownLeft",
      "mouthLowerDownRight",
      "mouthPressLeft",
      "mouthPressRight",
      "mouthStretchLeft",
      "mouthStretchRight",
      "tongueOut"
    };

    private void button1_Click(object sender, EventArgs e)
    {
      Debug.WriteLine("clicking first button");
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        string selectedFolder = folderBrowserDialog1.SelectedPath;
        folderPath.Text =  selectedFolder;
        sequence = QuillSequenceReader.Read(selectedFolder);
        ConfirmQuillValidity();
      }

    }

   private void createProject_Click(object sender, EventArgs e)
    {
      Debug.WriteLine("clicking submit button");
      saveDialog();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void folderPath_TextChanged(object sender, EventArgs e)
    {

    }

    private void warning_TextChanged(object sender, EventArgs e)
    {

    }

    /*
 * visits the direct children of the Root layer and prints the names (assuming this will be used with the Root layer as the argument
 * returns a list of the top-level children (can be layers or folders)
 * removes any spaces from names, and converts to all lowercase
 */
    List<string> LayerName(Layer layer)
    {
      layerDropdown.Items.Clear(); //if previously populated by a selection
      List<string> quillLayers = new List<string>();
      if (layer is LayerGroup)
      {
        foreach (Layer child in ((LayerGroup)layer).Children)
        {
          //Console.WriteLine(child.Name);
          quillLayers.Add(child.Name);
          layerDropdown.Items.Add(child.Name);
        }
      }
      return quillLayers;
    }

    void ConfirmQuillValidity()
    {
      if (sequence == null)
      {
        warning.ForeColor = System.Drawing.Color.Red;
        warning.Text = "Not a valid Quill file. Please select a valid Quill project folder.";
      }
      else
      {
        warning.ForeColor = System.Drawing.Color.Green;
        warning.Text = "Valid Quill folder selected.";

        //now make a dropdown box with list of layers to choose from
        var quillLayers = LayerName(sequence.RootLayer);
        //if empty of layers...
        if (quillLayers.Count == 0)
        {
          warning.ForeColor = System.Drawing.Color.Red;
          warning.Text = "Quill files contains no layers. Please choose a Quill project with at least one layer (face layer)";
          //hide dropdown
          layerDropdown.Visible = false;
          textBox1.Visible = false;
        }
        else
        {
          layerDropdown.Visible = true;
          textBox1.Visible = true;
          createProject.Visible = true;
          finalSubmitInstructions.Visible = true;
        }

      }
    }

    private void saveDialog()
    {
      Debug.WriteLine("running Save Dialog code");
      //open a dialog to save file
      SaveFileDialog sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        createQuillProject(Path.GetFullPath(sfd.FileName));
        Debug.WriteLine("creating Quill project");
      }
    }

    private void createQuillProject(string writePath)
    {
      Debug.WriteLine("string path: " + writePath);
      //set basehead variable to the chosen layer in the Quill sequence using the answer given (in dropdown)
      var baseHead = sequence.RootLayer.FindChild(layerDropdown.Text);
      Debug.WriteLine("selected text: " + layerDropdown.Text);

      //iterate through blendshape names and create a duplicate of head folder/layer with appropriate name
      if (baseHead != null)
      {
        for (int i = 0; i < blendshapeNames.Length; i++)
        {
          //needs to reference a new layer each time (otherwise, all new layers have the same name)
          Layer newLayer = baseHead.ShallowCopy(blendshapeNames[i]);
          newLayer.Visible = false; //assuming you will work on each layer separately, so starts off with all of them non-visible
          sequence.InsertLayerAt(newLayer, ""); //putting layers at the root of the existing sequence from the document
        }

        //Writes the modified sequence layer to a new Quill project
        QuillSequenceWriter.Write(sequence, writePath);
        MessageBox.Show("New Quill project folder with blendshape starter assets created! See: " + writePath);
        resetForm();
      }
      else
      {
        MessageBox.Show("Error. Did you select a layer from the dropdown menu? Please try again.");
        
      }
    }

    private void resetForm()
    {
      layerDropdown.Visible = false;
      textBox1.Visible = false;
      warning.Text = "";
      sequence = null;
      createProject.Visible = false;
      finalSubmitInstructions.Visible = false;
      folderPath.Text = "";

  }

    private void showLayerDropdown()
    {

    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
