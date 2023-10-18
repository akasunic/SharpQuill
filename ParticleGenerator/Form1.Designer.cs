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
            this.components = new System.ComponentModel.Container();
            this.genSteadyParts = new System.Windows.Forms.Button();
            this.chooseProjectFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveQuillProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.selectQuillButton = new System.Windows.Forms.Button();
            this.layersComboBox = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.readMeLink = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.checkBox_rotate = new System.Windows.Forms.CheckBox();
            this.quillErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.readPathChoice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quillErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // genSteadyParts
            // 
            this.genSteadyParts.Location = new System.Drawing.Point(206, 304);
            this.genSteadyParts.Name = "genSteadyParts";
            this.genSteadyParts.Size = new System.Drawing.Size(174, 23);
            this.genSteadyParts.TabIndex = 0;
            this.genSteadyParts.Text = "Generate Steady Particles";
            this.genSteadyParts.UseVisualStyleBackColor = true;
            this.genSteadyParts.Click += new System.EventHandler(this.genParts_click);
            // 
            // selectQuillButton
            // 
            this.selectQuillButton.Location = new System.Drawing.Point(26, 72);
            this.selectQuillButton.Name = "selectQuillButton";
            this.selectQuillButton.Size = new System.Drawing.Size(176, 24);
            this.selectQuillButton.TabIndex = 1;
            this.selectQuillButton.Text = "Select Quill project folder";
            this.selectQuillButton.UseVisualStyleBackColor = true;
            this.selectQuillButton.Click += new System.EventHandler(this.selectQuillButton_Click);
            // 
            // layersComboBox
            // 
            this.layersComboBox.FormattingEnabled = true;
            this.layersComboBox.Location = new System.Drawing.Point(224, 109);
            this.layersComboBox.Name = "layersComboBox";
            this.layersComboBox.Size = new System.Drawing.Size(221, 23);
            this.layersComboBox.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(217, 159);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of drawing duplicates";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of particle offsets (duplicates)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(217, 232);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(217, 42);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown3.TabIndex = 8;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "X-axis/length, as scale of Quill grid";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown4.Location = new System.Drawing.Point(217, 71);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown4.TabIndex = 10;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Y-axis/height, as scale of Quill grid";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown5.Location = new System.Drawing.Point(217, 100);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown5.TabIndex = 12;
            this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Z-axis/depth, as scale of Quill grid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(4, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Set scale of base area for particles";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(384, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Default values of 1 produce a cubic area with faces the size of Quill grid.";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Duplicate and randomly reposition and rotate particles";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(412, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Animation: Duplicate and offset particles, and loop at a time";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Layer containing particle drawing:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(30, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(314, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Steady Particles Generator for Quill";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // readMeLink
            // 
            this.readMeLink.AutoSize = true;
            this.readMeLink.Location = new System.Drawing.Point(30, 44);
            this.readMeLink.Name = "readMeLink";
            this.readMeLink.Size = new System.Drawing.Size(223, 15);
            this.readMeLink.TabIndex = 19;
            this.readMeLink.TabStop = true;
            this.readMeLink.Text = "Need help? See instructions and tips here";
            this.readMeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.readMeLink_Clicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numericUpDown6);
            this.panel1.Controls.Add(this.checkBox_rotate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.genSteadyParts);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(30, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 330);
            this.panel1.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Time in seconds at which to loop ";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown6.Location = new System.Drawing.Point(217, 261);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown6.TabIndex = 19;
            this.numericUpDown6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // checkBox_rotate
            // 
            this.checkBox_rotate.AutoSize = true;
            this.checkBox_rotate.Checked = true;
            this.checkBox_rotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rotate.Location = new System.Drawing.Point(12, 184);
            this.checkBox_rotate.Name = "checkBox_rotate";
            this.checkBox_rotate.Size = new System.Drawing.Size(465, 19);
            this.checkBox_rotate.TabIndex = 17;
            this.checkBox_rotate.Text = "Rotate particles (uncheck if you want to maintain the same rotation for all parti" +
    "cles)";
            this.checkBox_rotate.UseVisualStyleBackColor = true;
            // 
            // quillErrorProvider
            // 
            this.quillErrorProvider.ContainerControl = this;
            // 
            // readPathChoice
            // 
            this.readPathChoice.AutoSize = true;
            this.readPathChoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.readPathChoice.Location = new System.Drawing.Point(224, 77);
            this.readPathChoice.Name = "readPathChoice";
            this.readPathChoice.Size = new System.Drawing.Size(0, 15);
            this.readPathChoice.TabIndex = 22;
            this.readPathChoice.Click += new System.EventHandler(this.label13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 520);
            this.Controls.Add(this.readPathChoice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.readMeLink);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.layersComboBox);
            this.Controls.Add(this.selectQuillButton);
            this.Name = "Form1";
            this.Text = "Steady Particles Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quillErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button genSteadyParts;
    private FolderBrowserDialog chooseProjectFileDialog;
    private SaveFileDialog saveQuillProjectDialog;
    private Button selectQuillButton;
    private ComboBox layersComboBox;
    private NumericUpDown numericUpDown1;
    private Label label1;
    private Label label2;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown3;
    private Label label3;
    private NumericUpDown numericUpDown4;
    private Label label4;
    private NumericUpDown numericUpDown5;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private LinkLabel readMeLink;
    private Panel panel1;
    private Label label12;
    private NumericUpDown numericUpDown6;
    private CheckBox checkBox_rotate;
    private ErrorProvider quillErrorProvider;
    private Label readPathChoice;
  }
}
