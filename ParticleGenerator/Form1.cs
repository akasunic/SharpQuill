using SharpQuill;
using Newtonsoft.Json;
using System.Windows.Forms;

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
      int numObjs = 100;//have a dropdown/forced numerical entry-- use tooltips
      int numDups = 4;//have a dropdown/forced numerical entry-- use tooltips

      //sequence from file dialog, write path from save dialog-- see blendshape starter for ideas
      //readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Grid-test";
      
      //Sequence sequence = QuillSequenceReader.Read(readPath);
      string writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\randomizedParticles";
      //use dropdown to choose layer-- see blendshape app for ideas
      LayerPaint startLayer = (LayerPaint)sequence.RootLayer.FindChild("Heart");
      //these will be chosen as numbers/sliders
      float xFact = 1;
      float yFact = 1;
      float zFact = 1;

      //get value from form and then multiplay by 12600
      float loopTime = 12600;

      bool rotate = true;

      

      // Initialize the ParticleGenerator
      //particleGenerator = new ParticleGenerator();
      //public SteadyParticles(int numObjs, int numDups, Sequence sequence, LayerPaint startLayer, LayerPaint targetLayer, int xFact, int yFact, int zFact)
      steadyParticles = new SteadyParticles(numObjs, numDups, sequence, startLayer, xFact, yFact, zFact, loopTime, rotate);
      steadyParticles.GenerateSteadyParticles();
      QuillSequenceWriter.Write(sequence, writePath);
    }

  
    private void selectQuillButton_Click(object sender, EventArgs e)
    {

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

      // Navigate to a URL [this is a placeholder]. Better alternative to Google docs? Otherwise just use Google docs
      System.Diagnostics.Process.Start("http://www.microsoft.com");
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
