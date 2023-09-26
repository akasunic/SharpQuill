using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using SharpQuill;

namespace TestingBlendshapesFormApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private Sequence sequence; 

    private void button1_Click(object sender, EventArgs e)
    {

      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        string selectedFolder = folderBrowserDialog1.SelectedPath;
        folderPath.Text =  selectedFolder;
        sequence = QuillSequenceReader.Read(selectedFolder);
        ConfirmQuillValidity();
      }

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
        }

      }
    }

    private void showLayerDropdown()
    {

    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {

    }
  }
}
