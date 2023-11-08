﻿namespace VisemesWinFormsApp
{
  partial class VisemesForQuillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisemesForQuillForm));
            this.selectQuill_folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectQuill = new System.Windows.Forms.Button();
            this.step2 = new System.Windows.Forms.Label();
            this.step3_character = new System.Windows.Forms.Label();
            this.step3_mouth = new System.Windows.Forms.Label();
            this.step4 = new System.Windows.Forms.Label();
            this.step3 = new System.Windows.Forms.Label();
            this.step5_audioTitle = new System.Windows.Forms.Label();
            this.step5_audioFile = new System.Windows.Forms.Label();
            this.step5_charDropdown = new System.Windows.Forms.ComboBox();
            this.step5 = new System.Windows.Forms.Label();
            this.step1 = new System.Windows.Forms.Label();
            this.step4_audioTitle = new System.Windows.Forms.Label();
            this.delAudioButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.rhubarbexe = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.step3_line = new System.Windows.Forms.Label();
            this.step5_line = new System.Windows.Forms.Label();
            this.step4_line = new System.Windows.Forms.Label();
            this.step3panel = new System.Windows.Forms.Panel();
            this.step3_mouthContainerReminder = new System.Windows.Forms.Label();
            this.step4panel = new System.Windows.Forms.Panel();
            this.step4_addDelPanel = new System.Windows.Forms.Panel();
            this.addAudioButton = new System.Windows.Forms.Button();
            this.addAudioLabel = new System.Windows.Forms.Label();
            this.delAudioLabel = new System.Windows.Forms.Label();
            this.step4_optionalLabel = new System.Windows.Forms.Label();
            this.step4_textTitle = new System.Windows.Forms.Label();
            this.step5panel = new System.Windows.Forms.Panel();
            this.step5_innerPanel = new System.Windows.Forms.Panel();
            this.quillFolders_checklistBox = new System.Windows.Forms.CheckedListBox();
            this.selectRhubarb = new System.Windows.Forms.Button();
            this.rhubarbLoc = new System.Windows.Forms.Label();
            this.infoLink = new System.Windows.Forms.LinkLabel();
            this.step2_checkOnlyOneLabel = new System.Windows.Forms.Label();
            this.setRhubarb_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectedQuillPath = new System.Windows.Forms.Label();
            this.mainFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.step3Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.step4Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.step5Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.setAudio_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.setTxt_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.step3panel.SuspendLayout();
            this.step4panel.SuspendLayout();
            this.step4_addDelPanel.SuspendLayout();
            this.step5panel.SuspendLayout();
            this.step5_innerPanel.SuspendLayout();
            this.mainFlow.SuspendLayout();
            this.step3Flow.SuspendLayout();
            this.step4Flow.SuspendLayout();
            this.step5Flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectQuill
            // 
            this.selectQuill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(17)))));
            this.selectQuill.FlatAppearance.BorderSize = 0;
            this.selectQuill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectQuill.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectQuill.ForeColor = System.Drawing.Color.Black;
            this.selectQuill.Location = new System.Drawing.Point(87, 79);
            this.selectQuill.Name = "selectQuill";
            this.selectQuill.Size = new System.Drawing.Size(124, 24);
            this.selectQuill.TabIndex = 0;
            this.selectQuill.Text = "Select Quill project";
            this.selectQuill.UseVisualStyleBackColor = false;
            this.selectQuill.Click += new System.EventHandler(this.selectQuill_Click);
            // 
            // step2
            // 
            this.step2.AutoSize = true;
            this.step2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(126)))));
            this.step2.Location = new System.Drawing.Point(33, 135);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(286, 16);
            this.step2.TabIndex = 1;
            this.step2.Text = "Step 2:  Select your top-level Character folder(s)";
            // 
            // step3_character
            // 
            this.step3_character.AutoSize = true;
            this.step3_character.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step3_character.Location = new System.Drawing.Point(36, 35);
            this.step3_character.Name = "step3_character";
            this.step3_character.Size = new System.Drawing.Size(61, 15);
            this.step3_character.TabIndex = 1;
            this.step3_character.Text = "Character";
            // 
            // step3_mouth
            // 
            this.step3_mouth.AutoSize = true;
            this.step3_mouth.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step3_mouth.Location = new System.Drawing.Point(407, 35);
            this.step3_mouth.Name = "step3_mouth";
            this.step3_mouth.Size = new System.Drawing.Size(71, 15);
            this.step3_mouth.TabIndex = 2;
            this.step3_mouth.Text = "Mouth layer";
            // 
            // step4
            // 
            this.step4.AutoSize = true;
            this.step4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(126)))));
            this.step4.Location = new System.Drawing.Point(3, 10);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(286, 16);
            this.step4.TabIndex = 4;
            this.step4.Text = "Step 4:  Select Audio file(s) and (optional) scripts";
            // 
            // step3
            // 
            this.step3.AutoSize = true;
            this.step3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(126)))));
            this.step3.Location = new System.Drawing.Point(3, 5);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(319, 16);
            this.step3.TabIndex = 5;
            this.step3.Text = "Step 3: Match Character(s) to top-level Mouth layer(s)";
            // 
            // step5_audioTitle
            // 
            this.step5_audioTitle.AutoSize = true;
            this.step5_audioTitle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step5_audioTitle.Location = new System.Drawing.Point(37, 39);
            this.step5_audioTitle.Name = "step5_audioTitle";
            this.step5_audioTitle.Size = new System.Drawing.Size(39, 15);
            this.step5_audioTitle.TabIndex = 0;
            this.step5_audioTitle.Text = "Audio";
            // 
            // step5_audioFile
            // 
            this.step5_audioFile.AutoSize = true;
            this.step5_audioFile.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.step5_audioFile.Location = new System.Drawing.Point(32, 11);
            this.step5_audioFile.Name = "step5_audioFile";
            this.step5_audioFile.Size = new System.Drawing.Size(191, 16);
            this.step5_audioFile.TabIndex = 2;
            this.step5_audioFile.Text = "sample.wav (do last part of string)";
            // 
            // step5_charDropdown
            // 
            this.step5_charDropdown.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.step5_charDropdown.FormattingEnabled = true;
            this.step5_charDropdown.Location = new System.Drawing.Point(403, 3);
            this.step5_charDropdown.Name = "step5_charDropdown";
            this.step5_charDropdown.Size = new System.Drawing.Size(331, 24);
            this.step5_charDropdown.TabIndex = 3;
            // 
            // step5
            // 
            this.step5.AutoSize = true;
            this.step5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(126)))));
            this.step5.Location = new System.Drawing.Point(3, 13);
            this.step5.Name = "step5";
            this.step5.Size = new System.Drawing.Size(203, 16);
            this.step5.TabIndex = 7;
            this.step5.Text = "Step 5: Match Audio to characters";
            // 
            // step1
            // 
            this.step1.AutoSize = true;
            this.step1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(126)))));
            this.step1.Location = new System.Drawing.Point(33, 82);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(48, 16);
            this.step1.TabIndex = 8;
            this.step1.Text = "Step 1: ";
            // 
            // step4_audioTitle
            // 
            this.step4_audioTitle.AutoSize = true;
            this.step4_audioTitle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step4_audioTitle.Location = new System.Drawing.Point(35, 80);
            this.step4_audioTitle.Name = "step4_audioTitle";
            this.step4_audioTitle.Size = new System.Drawing.Size(135, 15);
            this.step4_audioTitle.TabIndex = 0;
            this.step4_audioTitle.Text = "Audio file (.wav or .ogg)";
            // 
            // delAudioButton
            // 
            this.delAudioButton.BackColor = System.Drawing.Color.White;
            this.delAudioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delAudioButton.BackgroundImage")));
            this.delAudioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.delAudioButton.FlatAppearance.BorderSize = 0;
            this.delAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delAudioButton.Font = new System.Drawing.Font("Yet R", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.delAudioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.delAudioButton.Location = new System.Drawing.Point(179, 3);
            this.delAudioButton.Name = "delAudioButton";
            this.delAudioButton.Size = new System.Drawing.Size(35, 34);
            this.delAudioButton.TabIndex = 6;
            this.delAudioButton.UseVisualStyleBackColor = false;
            this.delAudioButton.Click += new System.EventHandler(this.deleteAudio_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.submitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submitButton.Location = new System.Drawing.Point(3, 110);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(84, 34);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Create";
            this.submitButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoScroll = true;
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // step3_line
            // 
            this.step3_line.BackColor = System.Drawing.Color.Black;
            this.step3_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.step3_line.Location = new System.Drawing.Point(36, 50);
            this.step3_line.Name = "step3_line";
            this.step3_line.Size = new System.Drawing.Size(707, 2);
            this.step3_line.TabIndex = 12;
            // 
            // step5_line
            // 
            this.step5_line.BackColor = System.Drawing.Color.Black;
            this.step5_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.step5_line.Location = new System.Drawing.Point(36, 54);
            this.step5_line.Name = "step5_line";
            this.step5_line.Size = new System.Drawing.Size(707, 2);
            this.step5_line.TabIndex = 13;
            // 
            // step4_line
            // 
            this.step4_line.BackColor = System.Drawing.Color.Black;
            this.step4_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.step4_line.Location = new System.Drawing.Point(35, 98);
            this.step4_line.Name = "step4_line";
            this.step4_line.Size = new System.Drawing.Size(707, 2);
            this.step4_line.TabIndex = 15;
            // 
            // step3panel
            // 
            this.step3panel.Controls.Add(this.step3_mouthContainerReminder);
            this.step3panel.Controls.Add(this.step3_character);
            this.step3panel.Controls.Add(this.step3);
            this.step3panel.Controls.Add(this.step3_mouth);
            this.step3panel.Controls.Add(this.step3_line);
            this.step3panel.Location = new System.Drawing.Point(3, 3);
            this.step3panel.Name = "step3panel";
            this.step3panel.Size = new System.Drawing.Size(756, 57);
            this.step3panel.TabIndex = 17;
            this.step3panel.Paint += new System.Windows.Forms.PaintEventHandler(this.step3panel_Paint);
            // 
            // step3_mouthContainerReminder
            // 
            this.step3_mouthContainerReminder.AutoSize = true;
            this.step3_mouthContainerReminder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step3_mouthContainerReminder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(59)))), ((int)(((byte)(186)))));
            this.step3_mouthContainerReminder.Location = new System.Drawing.Point(475, 35);
            this.step3_mouthContainerReminder.Name = "step3_mouthContainerReminder";
            this.step3_mouthContainerReminder.Size = new System.Drawing.Size(278, 15);
            this.step3_mouthContainerReminder.TabIndex = 26;
            this.step3_mouthContainerReminder.Text = "must contain viseme folders: A, B, C, D, E, F, G, H, X ";
            // 
            // step4panel
            // 
            this.step4panel.Controls.Add(this.step4_addDelPanel);
            this.step4panel.Controls.Add(this.step4_optionalLabel);
            this.step4panel.Controls.Add(this.step4);
            this.step4panel.Controls.Add(this.step4_audioTitle);
            this.step4panel.Controls.Add(this.step4_line);
            this.step4panel.Controls.Add(this.step4_textTitle);
            this.step4panel.Location = new System.Drawing.Point(3, 3);
            this.step4panel.Name = "step4panel";
            this.step4panel.Size = new System.Drawing.Size(752, 103);
            this.step4panel.TabIndex = 18;
            // 
            // step4_addDelPanel
            // 
            this.step4_addDelPanel.Controls.Add(this.addAudioButton);
            this.step4_addDelPanel.Controls.Add(this.delAudioButton);
            this.step4_addDelPanel.Controls.Add(this.addAudioLabel);
            this.step4_addDelPanel.Controls.Add(this.delAudioLabel);
            this.step4_addDelPanel.Location = new System.Drawing.Point(36, 29);
            this.step4_addDelPanel.Name = "step4_addDelPanel";
            this.step4_addDelPanel.Size = new System.Drawing.Size(704, 48);
            this.step4_addDelPanel.TabIndex = 21;
            // 
            // addAudioButton
            // 
            this.addAudioButton.BackColor = System.Drawing.Color.White;
            this.addAudioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addAudioButton.BackgroundImage")));
            this.addAudioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addAudioButton.FlatAppearance.BorderSize = 0;
            this.addAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAudioButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addAudioButton.ForeColor = System.Drawing.Color.Black;
            this.addAudioButton.Location = new System.Drawing.Point(2, 4);
            this.addAudioButton.Name = "addAudioButton";
            this.addAudioButton.Size = new System.Drawing.Size(44, 32);
            this.addAudioButton.TabIndex = 16;
            this.addAudioButton.UseVisualStyleBackColor = false;
            this.addAudioButton.Click += new System.EventHandler(this.addAudioButton_Click);
            // 
            // addAudioLabel
            // 
            this.addAudioLabel.AutoSize = true;
            this.addAudioLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addAudioLabel.Location = new System.Drawing.Point(51, 12);
            this.addAudioLabel.Name = "addAudioLabel";
            this.addAudioLabel.Size = new System.Drawing.Size(108, 15);
            this.addAudioLabel.TabIndex = 17;
            this.addAudioLabel.Text = "Add new audio file";
            // 
            // delAudioLabel
            // 
            this.delAudioLabel.AutoSize = true;
            this.delAudioLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.delAudioLabel.Location = new System.Drawing.Point(220, 12);
            this.delAudioLabel.Name = "delAudioLabel";
            this.delAudioLabel.Size = new System.Drawing.Size(149, 15);
            this.delAudioLabel.TabIndex = 18;
            this.delAudioLabel.Text = "Delete selected audio files";
            // 
            // step4_optionalLabel
            // 
            this.step4_optionalLabel.AutoSize = true;
            this.step4_optionalLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step4_optionalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(59)))), ((int)(((byte)(186)))));
            this.step4_optionalLabel.Location = new System.Drawing.Point(549, 80);
            this.step4_optionalLabel.Name = "step4_optionalLabel";
            this.step4_optionalLabel.Size = new System.Drawing.Size(61, 15);
            this.step4_optionalLabel.TabIndex = 19;
            this.step4_optionalLabel.Text = "*optional*";
            // 
            // step4_textTitle
            // 
            this.step4_textTitle.AutoSize = true;
            this.step4_textTitle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step4_textTitle.Location = new System.Drawing.Point(408, 80);
            this.step4_textTitle.Name = "step4_textTitle";
            this.step4_textTitle.Size = new System.Drawing.Size(135, 15);
            this.step4_textTitle.TabIndex = 1;
            this.step4_textTitle.Text = "Text Script of Audio (.txt)";
            // 
            // step5panel
            // 
            this.step5panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.step5panel.Controls.Add(this.step5_innerPanel);
            this.step5panel.Controls.Add(this.step5);
            this.step5panel.Controls.Add(this.submitButton);
            this.step5panel.Controls.Add(this.step5_line);
            this.step5panel.Controls.Add(this.step5_audioTitle);
            this.step5panel.Location = new System.Drawing.Point(3, 3);
            this.step5panel.Name = "step5panel";
            this.step5panel.Size = new System.Drawing.Size(755, 147);
            this.step5panel.TabIndex = 19;
            // 
            // step5_innerPanel
            // 
            this.step5_innerPanel.Controls.Add(this.step5_charDropdown);
            this.step5_innerPanel.Controls.Add(this.step5_audioFile);
            this.step5_innerPanel.Location = new System.Drawing.Point(3, 57);
            this.step5_innerPanel.Name = "step5_innerPanel";
            this.step5_innerPanel.Size = new System.Drawing.Size(741, 35);
            this.step5_innerPanel.TabIndex = 16;
            // 
            // quillFolders_checklistBox
            // 
            this.quillFolders_checklistBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.quillFolders_checklistBox.FormattingEnabled = true;
            this.quillFolders_checklistBox.Location = new System.Drawing.Point(72, 154);
            this.quillFolders_checklistBox.Name = "quillFolders_checklistBox";
            this.quillFolders_checklistBox.ScrollAlwaysVisible = true;
            this.quillFolders_checklistBox.Size = new System.Drawing.Size(704, 72);
            this.quillFolders_checklistBox.TabIndex = 20;
            this.quillFolders_checklistBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.quillFolders_checklistBox_ItemCheckEvent);
            // 
            // selectRhubarb
            // 
            this.selectRhubarb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(40)))), ((int)(((byte)(127)))));
            this.selectRhubarb.FlatAppearance.BorderSize = 0;
            this.selectRhubarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectRhubarb.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectRhubarb.ForeColor = System.Drawing.Color.White;
            this.selectRhubarb.Location = new System.Drawing.Point(33, 43);
            this.selectRhubarb.Name = "selectRhubarb";
            this.selectRhubarb.Size = new System.Drawing.Size(209, 24);
            this.selectRhubarb.TabIndex = 22;
            this.selectRhubarb.Text = "Set or change Rhubarb location";
            this.selectRhubarb.UseVisualStyleBackColor = false;
            this.selectRhubarb.Click += new System.EventHandler(this.selectRhubarb_Click);
            // 
            // rhubarbLoc
            // 
            this.rhubarbLoc.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rhubarbLoc.Location = new System.Drawing.Point(255, 47);
            this.rhubarbLoc.Name = "rhubarbLoc";
            this.rhubarbLoc.Size = new System.Drawing.Size(519, 56);
            this.rhubarbLoc.TabIndex = 23;
            this.rhubarbLoc.Text = "C://aewrioij//oaihajewoirj//oaeworijawier//rhubarb.exe";
            // 
            // infoLink
            // 
            this.infoLink.AutoSize = true;
            this.infoLink.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoLink.Location = new System.Drawing.Point(33, 9);
            this.infoLink.Name = "infoLink";
            this.infoLink.Size = new System.Drawing.Size(145, 17);
            this.infoLink.TabIndex = 24;
            this.infoLink.TabStop = true;
            this.infoLink.Text = "Click here for more info";
            this.infoLink.Click += new System.EventHandler(this.infoLink_Click);
            // 
            // step2_checkOnlyOneLabel
            // 
            this.step2_checkOnlyOneLabel.AutoSize = true;
            this.step2_checkOnlyOneLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.step2_checkOnlyOneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(59)))), ((int)(((byte)(186)))));
            this.step2_checkOnlyOneLabel.Location = new System.Drawing.Point(325, 135);
            this.step2_checkOnlyOneLabel.Name = "step2_checkOnlyOneLabel";
            this.step2_checkOnlyOneLabel.Size = new System.Drawing.Size(202, 15);
            this.step2_checkOnlyOneLabel.TabIndex = 25;
            this.step2_checkOnlyOneLabel.Text = "check only one folder per character";
            // 
            // setRhubarb_openFileDialog
            // 
            this.setRhubarb_openFileDialog.FileName = "setRhubarb_openFileDialog";
            // 
            // selectedQuillPath
            // 
            this.selectedQuillPath.AutoSize = true;
            this.selectedQuillPath.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedQuillPath.Location = new System.Drawing.Point(91, 106);
            this.selectedQuillPath.Name = "selectedQuillPath";
            this.selectedQuillPath.Size = new System.Drawing.Size(128, 17);
            this.selectedQuillPath.TabIndex = 27;
            this.selectedQuillPath.Text = "No project selected";
            // 
            // mainFlow
            // 
            this.mainFlow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mainFlow.AutoSize = true;
            this.mainFlow.Controls.Add(this.step3Flow);
            this.mainFlow.Controls.Add(this.step4Flow);
            this.mainFlow.Controls.Add(this.step5Flow);
            this.mainFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlow.Location = new System.Drawing.Point(24, 232);
            this.mainFlow.Name = "mainFlow";
            this.mainFlow.Size = new System.Drawing.Size(768, 360);
            this.mainFlow.TabIndex = 28;
            // 
            // step3Flow
            // 
            this.step3Flow.AutoSize = true;
            this.step3Flow.Controls.Add(this.step3panel);
            this.step3Flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.step3Flow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.step3Flow.Location = new System.Drawing.Point(3, 3);
            this.step3Flow.Name = "step3Flow";
            this.step3Flow.Size = new System.Drawing.Size(762, 63);
            this.step3Flow.TabIndex = 20;
            // 
            // step4Flow
            // 
            this.step4Flow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.step4Flow.AutoSize = true;
            this.step4Flow.Controls.Add(this.step4panel);
            this.step4Flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.step4Flow.Location = new System.Drawing.Point(5, 72);
            this.step4Flow.Name = "step4Flow";
            this.step4Flow.Size = new System.Drawing.Size(758, 109);
            this.step4Flow.TabIndex = 21;
            // 
            // step5Flow
            // 
            this.step5Flow.AutoSize = true;
            this.step5Flow.Controls.Add(this.step5panel);
            this.step5Flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.step5Flow.Location = new System.Drawing.Point(3, 187);
            this.step5Flow.Name = "step5Flow";
            this.step5Flow.Size = new System.Drawing.Size(761, 153);
            this.step5Flow.TabIndex = 22;
            // 
            // setAudio_openFileDialog
            // 
            this.setAudio_openFileDialog.FileName = "openFileDialog1";
            // 
            // setTxt_openFileDialog
            // 
            this.setTxt_openFileDialog.FileName = "openFileDialog1";
            // 
            // VisemesForQuillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 603);
            this.Controls.Add(this.mainFlow);
            this.Controls.Add(this.selectedQuillPath);
            this.Controls.Add(this.step2_checkOnlyOneLabel);
            this.Controls.Add(this.infoLink);
            this.Controls.Add(this.rhubarbLoc);
            this.Controls.Add(this.selectRhubarb);
            this.Controls.Add(this.quillFolders_checklistBox);
            this.Controls.Add(this.step1);
            this.Controls.Add(this.step2);
            this.Controls.Add(this.selectQuill);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "VisemesForQuillForm";
            this.Text = "Viseme Automator for Quill";
            this.Load += new System.EventHandler(this.VisemesForQuillForm_Load_1);
            this.step3panel.ResumeLayout(false);
            this.step3panel.PerformLayout();
            this.step4panel.ResumeLayout(false);
            this.step4panel.PerformLayout();
            this.step4_addDelPanel.ResumeLayout(false);
            this.step4_addDelPanel.PerformLayout();
            this.step5panel.ResumeLayout(false);
            this.step5panel.PerformLayout();
            this.step5_innerPanel.ResumeLayout(false);
            this.step5_innerPanel.PerformLayout();
            this.mainFlow.ResumeLayout(false);
            this.mainFlow.PerformLayout();
            this.step3Flow.ResumeLayout(false);
            this.step4Flow.ResumeLayout(false);
            this.step5Flow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private FolderBrowserDialog selectQuill_folderDialog;
    private Button selectQuill;
    private Label step2;
    private Label step4;
    private Label step3;
    private Label step5;
    private Label step1;
    private Label step5_audioTitle;
    private Label step5_audioFile;
    private ComboBox step5_charDropdown;
    private Label step4_audioTitle;
    private Button submitButton;
    private ToolTip rhubarbexe;
    private ToolTip toolTip2;
    private ToolTip toolTip3;
    private TableLayoutPanel tableLayoutPanel4;

    private TableLayoutPanel tableLayoutPanel5;

    private Label step3_character;
    private Label step3_mouth;
    private Button delAudioButton;
    private Label step3_line;
    private Label step5_line;
    private Label step4_line;
    private Panel step3panel;
    private Panel step4panel;
    private Panel step5panel;
    private Button addAudioButton;
    private Label delAudioLabel;
    private Label addAudioLabel;
    private Label step4_textTitle;
    private CheckedListBox quillFolders_checklistBox;
    private Panel step4_addDelPanel;
    private Panel step5_innerPanel;
    private Button selectRhubarb;
    private Label rhubarbLoc;
    private LinkLabel infoLink;
    private Label step4_optionalLabel;
    private Label step2_checkOnlyOneLabel;
    private Label step3_mouthContainerReminder;
    private OpenFileDialog setRhubarb_openFileDialog;
    private Label selectedQuillPath;
    private FlowLayoutPanel mainFlow;
    private FlowLayoutPanel step3Flow;
    private FlowLayoutPanel step4Flow;
    private FlowLayoutPanel step5Flow;
    private OpenFileDialog setAudio_openFileDialog;
    private OpenFileDialog setTxt_openFileDialog;
  }
}
