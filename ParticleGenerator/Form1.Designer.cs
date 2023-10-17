namespace ParticleGenerator
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.genSteadyParts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genSteadyParts
            // 
            this.genSteadyParts.Location = new System.Drawing.Point(279, 262);
            this.genSteadyParts.Name = "genSteadyParts";
            this.genSteadyParts.Size = new System.Drawing.Size(174, 23);
            this.genSteadyParts.TabIndex = 0;
            this.genSteadyParts.Text = "Generate Particles";
            this.genSteadyParts.UseVisualStyleBackColor = true;
            this.genSteadyParts.Click += new System.EventHandler(this.genParts_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.genSteadyParts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

    }

    #endregion

    private Button genSteadyParts;
  }
}
