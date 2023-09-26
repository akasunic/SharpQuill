namespace TestingBlendshapesFormApp
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    //I should rename these later...
    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pickfileInstructions = new System.Windows.Forms.TextBox();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.warning = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pickfileInstructions
            // 
            this.pickfileInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pickfileInstructions.Location = new System.Drawing.Point(37, 26);
            this.pickfileInstructions.Multiline = true;
            this.pickfileInstructions.Name = "pickfileInstructions";
            this.pickfileInstructions.ReadOnly = true;
            this.pickfileInstructions.Size = new System.Drawing.Size(477, 30);
            this.pickfileInstructions.TabIndex = 1;
            this.pickfileInstructions.Text = "Please select the Quill project folder you are using. It should contain 3 files: " +
    "Quill.json, Quill.qbin, State.json";
            this.pickfileInstructions.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // folderPath
            // 
            this.folderPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.folderPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.folderPath.Location = new System.Drawing.Point(207, 62);
            this.folderPath.Multiline = true;
            this.folderPath.Name = "folderPath";
            this.folderPath.ReadOnly = true;
            this.folderPath.Size = new System.Drawing.Size(307, 51);
            this.folderPath.TabIndex = 2;
            this.folderPath.TextChanged += new System.EventHandler(this.folderPath_TextChanged);
            // 
            // warning
            // 
            this.warning.BackColor = System.Drawing.SystemColors.Menu;
            this.warning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.warning.ForeColor = System.Drawing.Color.Black;
            this.warning.Location = new System.Drawing.Point(37, 91);
            this.warning.Multiline = true;
            this.warning.Name = "warning";
            this.warning.ReadOnly = true;
            this.warning.Size = new System.Drawing.Size(488, 49);
            this.warning.TabIndex = 3;
            this.warning.TextChanged += new System.EventHandler(this.warning_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.warning);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.pickfileInstructions);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Quill Blendshape Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private FolderBrowserDialog folderBrowserDialog1;
    private Button button1;
    private TextBox pickfileInstructions;
    private TextBox folderPath;
    private TextBox warning;
  }
}
