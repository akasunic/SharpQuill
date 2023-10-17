using SharpQuill;
using Newtonsoft.Json;
namespace ParticleGenerator
{
  public partial class Form1 : Form
  {
    private SteadyParticles? steadyParticles;//making nullable


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
      string readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Grid-test";
      Sequence sequence = QuillSequenceReader.Read(readPath);
      string writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\randomizedParticles";
      //use dropdown to choose layer-- see blendshape app for ideas
      LayerPaint startLayer = (LayerPaint)sequence.RootLayer.FindChild("Heart");
      //these will be chosen as numbers/sliders
      int xFact = 1;
      int yFact = 1;
      int zFact = 1;



      // Initialize the ParticleGenerator
      //particleGenerator = new ParticleGenerator();
      //public SteadyParticles(int numObjs, int numDups, Sequence sequence, LayerPaint startLayer, LayerPaint targetLayer, int xFact, int yFact, int zFact)
      steadyParticles = new SteadyParticles(numObjs, numDups, sequence, startLayer, xFact, yFact, zFact);
      steadyParticles.GenerateSteadyParticles();
      QuillSequenceWriter.Write(sequence, writePath);
    }

    private void button1_Click(object sender, EventArgs e)
    {

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
  }
}
