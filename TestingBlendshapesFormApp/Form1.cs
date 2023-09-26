using System;
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

    void ConfirmQuillValidity()
    {
      if (sequence == null)
      {
        warning.ForeColor = System.Drawing.Color.Red;
        warning.Text = "Not a valid Quill file. Please select a valid Quill project folder.";
      }
      else
      {
        warning.ForeColor = System.Drawing.Color.Black;
        warning.Text = "Valid Quill folder selected.";
        //And now radio buttons to select the proper layer
        //may want a new fnt for this
      }
    }
  }
}
