namespace ParticleGenerator
{
  partial class ParticlesForm
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
            this.chooseProjectFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveQuillProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.selectQuillButton = new System.Windows.Forms.Button();
            this.layersComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.readMeLink = new System.Windows.Forms.LinkLabel();
            this.quillErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.readPathChoice = new System.Windows.Forms.Label();
            this.noPaintLayersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.noLayerChosenErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.noStrokesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.noProjectChosenErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dupChoice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zChoice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yChoice = new System.Windows.Forms.NumericUpDown();
            this.objChoice = new System.Windows.Forms.NumericUpDown();
            this.xChoice = new System.Windows.Forms.NumericUpDown();
            this.genSteadyParts = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_rotate = new System.Windows.Forms.CheckBox();
            this.secondsChoice = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.timeAllowRangeText = new System.Windows.Forms.Label();
            this.offsetDupsAllowRangeText = new System.Windows.Forms.Label();
            this.drawDupRangeAllowText = new System.Windows.Forms.Label();
            this.gridScaleRangeAllowText = new System.Windows.Forms.Label();
            this.warningText = new System.Windows.Forms.Label();
            this.projectCreatedText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quillErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPaintLayersErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noLayerChosenErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noStrokesErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noProjectChosenErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dupChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // selectQuillButton
            // 
            this.selectQuillButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.selectQuillButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectQuillButton.Location = new System.Drawing.Point(26, 72);
            this.selectQuillButton.Name = "selectQuillButton";
            this.selectQuillButton.Size = new System.Drawing.Size(176, 24);
            this.selectQuillButton.TabIndex = 1;
            this.selectQuillButton.Text = "Select Quill project folder";
            this.selectQuillButton.UseVisualStyleBackColor = false;
            this.selectQuillButton.Click += new System.EventHandler(this.selectQuillButton_Click);
            // 
            // layersComboBox
            // 
            this.layersComboBox.FormattingEnabled = true;
            this.layersComboBox.Location = new System.Drawing.Point(224, 109);
            this.layersComboBox.Name = "layersComboBox";
            this.layersComboBox.Size = new System.Drawing.Size(221, 23);
            this.layersComboBox.TabIndex = 2;
            this.layersComboBox.TextChanged += new System.EventHandler(this.ErrorRemovingChangeHandler);
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
            // 
            // readMeLink
            // 
            this.readMeLink.AutoSize = true;
            this.readMeLink.Location = new System.Drawing.Point(30, 44);
            this.readMeLink.Name = "readMeLink";
            this.readMeLink.Size = new System.Drawing.Size(223, 15);
            this.readMeLink.TabIndex = 19;
            this.readMeLink.TabStop = true;
            this.readMeLink.Text = "For more info and instructions, click here";
            this.readMeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.readMeLink_Clicked);
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
            // 
            // noPaintLayersErrorProvider
            // 
            this.noPaintLayersErrorProvider.ContainerControl = this;
            // 
            // noLayerChosenErrorProvider
            // 
            this.noLayerChosenErrorProvider.ContainerControl = this;
            // 
            // noStrokesErrorProvider
            // 
            this.noStrokesErrorProvider.ContainerControl = this;
            // 
            // noProjectChosenErrorProvider
            // 
            this.noProjectChosenErrorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "X-axis/length, as scale of Quill grid";
            this.label3.UseWaitCursor = true;
            // 
            // dupChoice
            // 
            this.dupChoice.Location = new System.Drawing.Point(239, 368);
            this.dupChoice.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.dupChoice.Name = "dupChoice";
            this.dupChoice.Size = new System.Drawing.Size(120, 23);
            this.dupChoice.TabIndex = 6;
            this.dupChoice.UseWaitCursor = true;
            this.dupChoice.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of particle offsets (duplicates)";
            this.label2.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(25, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Duplicate and randomly reposition and rotate particles";
            this.label8.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Z-axis/depth, as scale of Quill grid";
            this.label5.UseWaitCursor = true;
            // 
            // zChoice
            // 
            this.zChoice.DecimalPlaces = 2;
            this.zChoice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.zChoice.Location = new System.Drawing.Point(239, 236);
            this.zChoice.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.zChoice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.zChoice.Name = "zChoice";
            this.zChoice.Size = new System.Drawing.Size(120, 23);
            this.zChoice.TabIndex = 12;
            this.zChoice.UseWaitCursor = true;
            this.zChoice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of drawing duplicates";
            this.label1.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(25, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(412, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Animation: Duplicate and offset particles, and loop at a time";
            this.label9.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Y-axis/height, as scale of Quill grid";
            this.label4.UseWaitCursor = true;
            // 
            // yChoice
            // 
            this.yChoice.DecimalPlaces = 2;
            this.yChoice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.yChoice.Location = new System.Drawing.Point(239, 207);
            this.yChoice.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.yChoice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.yChoice.Name = "yChoice";
            this.yChoice.Size = new System.Drawing.Size(120, 23);
            this.yChoice.TabIndex = 10;
            this.yChoice.UseWaitCursor = true;
            this.yChoice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // objChoice
            // 
            this.objChoice.Location = new System.Drawing.Point(239, 295);
            this.objChoice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.objChoice.Name = "objChoice";
            this.objChoice.Size = new System.Drawing.Size(120, 23);
            this.objChoice.TabIndex = 3;
            this.objChoice.UseWaitCursor = true;
            this.objChoice.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // xChoice
            // 
            this.xChoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xChoice.DecimalPlaces = 2;
            this.xChoice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.xChoice.Location = new System.Drawing.Point(239, 178);
            this.xChoice.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.xChoice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.xChoice.Name = "xChoice";
            this.xChoice.Size = new System.Drawing.Size(120, 23);
            this.xChoice.TabIndex = 8;
            this.xChoice.UseWaitCursor = true;
            this.xChoice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // genSteadyParts
            // 
            this.genSteadyParts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.genSteadyParts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.genSteadyParts.Location = new System.Drawing.Point(34, 467);
            this.genSteadyParts.Name = "genSteadyParts";
            this.genSteadyParts.Size = new System.Drawing.Size(174, 23);
            this.genSteadyParts.TabIndex = 0;
            this.genSteadyParts.Text = "Generate Steady Particles";
            this.genSteadyParts.UseVisualStyleBackColor = false;
            this.genSteadyParts.UseWaitCursor = true;
            this.genSteadyParts.Click += new System.EventHandler(this.genParts_click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(384, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Default values of 1 produce a cubic area with faces the size of Quill grid.";
            this.label7.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(26, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Set scale of base area for particles";
            this.label6.UseWaitCursor = true;
            // 
            // checkBox_rotate
            // 
            this.checkBox_rotate.AutoSize = true;
            this.checkBox_rotate.Checked = true;
            this.checkBox_rotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rotate.Location = new System.Drawing.Point(26, 324);
            this.checkBox_rotate.Name = "checkBox_rotate";
            this.checkBox_rotate.Size = new System.Drawing.Size(465, 19);
            this.checkBox_rotate.TabIndex = 17;
            this.checkBox_rotate.Text = "Rotate particles (uncheck if you want to maintain the same rotation for all parti" +
    "cles)";
            this.checkBox_rotate.UseVisualStyleBackColor = true;
            this.checkBox_rotate.UseWaitCursor = true;
            // 
            // secondsChoice
            // 
            this.secondsChoice.DecimalPlaces = 1;
            this.secondsChoice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.secondsChoice.Location = new System.Drawing.Point(239, 397);
            this.secondsChoice.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsChoice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.secondsChoice.Name = "secondsChoice";
            this.secondsChoice.Size = new System.Drawing.Size(120, 23);
            this.secondsChoice.TabIndex = 19;
            this.secondsChoice.UseWaitCursor = true;
            this.secondsChoice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 405);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Time in seconds at which to loop ";
            this.label12.UseWaitCursor = true;
            // 
            // timeAllowRangeText
            // 
            this.timeAllowRangeText.AutoSize = true;
            this.timeAllowRangeText.Location = new System.Drawing.Point(378, 405);
            this.timeAllowRangeText.Name = "timeAllowRangeText";
            this.timeAllowRangeText.Size = new System.Drawing.Size(87, 15);
            this.timeAllowRangeText.TabIndex = 25;
            this.timeAllowRangeText.Text = "allowed range: ";
            this.timeAllowRangeText.UseWaitCursor = true;
            // 
            // offsetDupsAllowRangeText
            // 
            this.offsetDupsAllowRangeText.AutoSize = true;
            this.offsetDupsAllowRangeText.Location = new System.Drawing.Point(378, 376);
            this.offsetDupsAllowRangeText.Name = "offsetDupsAllowRangeText";
            this.offsetDupsAllowRangeText.Size = new System.Drawing.Size(87, 15);
            this.offsetDupsAllowRangeText.TabIndex = 24;
            this.offsetDupsAllowRangeText.Text = "allowed range: ";
            this.offsetDupsAllowRangeText.UseWaitCursor = true;
            // 
            // drawDupRangeAllowText
            // 
            this.drawDupRangeAllowText.AutoSize = true;
            this.drawDupRangeAllowText.Location = new System.Drawing.Point(378, 297);
            this.drawDupRangeAllowText.Name = "drawDupRangeAllowText";
            this.drawDupRangeAllowText.Size = new System.Drawing.Size(87, 15);
            this.drawDupRangeAllowText.TabIndex = 23;
            this.drawDupRangeAllowText.Text = "allowed range: ";
            this.drawDupRangeAllowText.UseWaitCursor = true;
            // 
            // gridScaleRangeAllowText
            // 
            this.gridScaleRangeAllowText.AutoSize = true;
            this.gridScaleRangeAllowText.Location = new System.Drawing.Point(378, 180);
            this.gridScaleRangeAllowText.Name = "gridScaleRangeAllowText";
            this.gridScaleRangeAllowText.Size = new System.Drawing.Size(87, 15);
            this.gridScaleRangeAllowText.TabIndex = 22;
            this.gridScaleRangeAllowText.Text = "allowed range: ";
            this.gridScaleRangeAllowText.UseWaitCursor = true;
            // 
            // warningText
            // 
            this.warningText.AutoSize = true;
            this.warningText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.warningText.ForeColor = System.Drawing.Color.Red;
            this.warningText.Location = new System.Drawing.Point(34, 449);
            this.warningText.Name = "warningText";
            this.warningText.Size = new System.Drawing.Size(352, 15);
            this.warningText.TabIndex = 21;
            this.warningText.Text = "*Quill project cannot be generated. Please fix errors and try again.";
            this.warningText.UseWaitCursor = true;
            this.warningText.Visible = false;
            // 
            // projectCreatedText
            // 
            this.projectCreatedText.AutoSize = true;
            this.projectCreatedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.projectCreatedText.ForeColor = System.Drawing.SystemColors.Highlight;
            this.projectCreatedText.Location = new System.Drawing.Point(214, 471);
            this.projectCreatedText.Name = "projectCreatedText";
            this.projectCreatedText.Size = new System.Drawing.Size(19, 15);
            this.projectCreatedText.TabIndex = 20;
            this.projectCreatedText.Text = "    ";
            this.projectCreatedText.UseWaitCursor = true;
            // 
            // ParticlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(733, 520);
            this.Controls.Add(this.timeAllowRangeText);
            this.Controls.Add(this.readPathChoice);
            this.Controls.Add(this.offsetDupsAllowRangeText);
            this.Controls.Add(this.drawDupRangeAllowText);
            this.Controls.Add(this.readMeLink);
            this.Controls.Add(this.gridScaleRangeAllowText);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.warningText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.projectCreatedText);
            this.Controls.Add(this.layersComboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.selectQuillButton);
            this.Controls.Add(this.secondsChoice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_rotate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dupChoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genSteadyParts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.xChoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.objChoice);
            this.Controls.Add(this.zChoice);
            this.Controls.Add(this.yChoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Name = "ParticlesForm";
            this.Text = "Steady Particles Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quillErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPaintLayersErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noLayerChosenErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noStrokesErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noProjectChosenErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dupChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsChoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private FolderBrowserDialog chooseProjectFileDialog;
    private SaveFileDialog saveQuillProjectDialog;
    private Button selectQuillButton;
    private ComboBox layersComboBox;
    private Label label10;
    private Label label11;
    private LinkLabel readMeLink;
    private ErrorProvider quillErrorProvider;
    private Label readPathChoice;
    private ErrorProvider noPaintLayersErrorProvider;
    private ErrorProvider noLayerChosenErrorProvider;
    private ErrorProvider noStrokesErrorProvider;
    private ErrorProvider noProjectChosenErrorProvider;
    private Label label12;
    private NumericUpDown secondsChoice;
    private CheckBox checkBox_rotate;
    private Label label6;
    private Label label7;
    private Button genSteadyParts;
    private NumericUpDown xChoice;
    private NumericUpDown objChoice;
    private NumericUpDown yChoice;
    private Label label4;
    private Label label9;
    private Label label1;
    private NumericUpDown zChoice;
    private Label label5;
    private Label label8;
    private Label label2;
    private NumericUpDown dupChoice;
    private Label label3;
    private Label warningText;
    private Label gridScaleRangeAllowText;
    private Label drawDupRangeAllowText;
    private Label timeAllowRangeText;
    private Label offsetDupsAllowRangeText;
    private Label projectCreatedText;
  }
}
