using System.Diagnostics;
using SharpQuill;
using Newtonsoft.Json;
using System.Configuration;
using System.Windows.Forms.Design;

namespace VisemesWinFormsApp
{
  public partial class VisemesForQuillForm : Form
  {
    private string rhubarbExecPath;
    private string? quillPath;
    Sequence sequence;
    private Dictionary<string, Layer> characterLayers = new Dictionary<string, Layer>();
    private Dictionary<string, Audio> audios = new Dictionary<string, Audio>();
   // private Dictionary<string, string> txtFiles = new Dictionary<string, string>();
    private Dictionary<string, Character> chosenCharacters= new Dictionary<string, Character>();
    public VisemesForQuillForm()
    {
      InitializeComponent();
      //see if Rhubarb exec location is already set. If so, prepopulate form and data
      //load config file
      // Load the configuration file
      // To read a setting
      string rhubarbPath = Settings1.Default.RhubarbPath;
      if (rhubarbPath == null || rhubarbPath == "")
      {

        //make sure these instructions are accurate
        rhubarbLoc.Text = "Please set the location of your Rhubarb executable (version 1.13.0)";
        //trash can red: 255, 63, 91
        //pink color: 245, 59, 186
        rhubarbLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(63)))), ((int)(((byte)(91
          )))));

      }
      else
      {
        rhubarbExecPath = rhubarbPath;
        rhubarbLoc.Text = rhubarbPath;
        rhubarbLoc.ForeColor = System.Drawing.Color.Black;
      }
    }



    //here comes all the code for handling all the interactions (utilizing instances and methods for VG class)



    private void VisemesForQuillForm_Load_1(object sender, EventArgs e)
    {

    }

    private void selectQuill_Click(object sender, EventArgs e)
    {
      if (selectQuill_folderDialog.ShowDialog() == DialogResult.OK)
      {
        //clear checklist (and others-- chars and mouth layers for step3, chars for step 5
        quillFolders_checklistBox.Items.Clear();
       

        quillPath = selectQuill_folderDialog.SelectedPath;
        selectedQuillPath.Text = "Selected: " + quillPath;
        sequence = QuillSequenceReader.Read(quillPath);
        if (sequence == null)
        {
           quillErrorProvider.SetError(selectQuill, "Not a valid Quill project folder. Should be a folder containing Quill.json, State,json, Quill.qbin");
        }
        else
        {
          quillErrorProvider.SetError(selectQuill, String.Empty);
          populateCheckboxList(sequence.RootLayer, 0);
        }
      }
    }



    //recursive method, goes through all layers of selected project
    // if a group layer, keeps recursively calling, if paint layer, adds to comboxbox
    private void populateCheckboxList(Layer layer, int offset)
    {
      string spaces = new String(' ', offset * 5);
      //not including paint layers, because it should be a group layer!
      if (layer.Type.ToString() == "Group" && offset < 3)//okay, 3 is somewhat arbitrary... maybe a better way to do this??
      {
        //add to checkbox list
        if (layer.Name != "Root")
        {
          quillFolders_checklistBox.Items.Add(spaces + layer.Name);
          characterLayers.Add(layer.Name, layer);
        }

        foreach (Layer child in ((LayerGroup)layer).Children)
        {
          populateCheckboxList(child, offset + 1);
        }
      }

    }

    //I THINK THIS SHOULD BE RUN WHEN YOU CLICK ON CHECKEDLIST BOX!!
    //needs to add a new "row" (panel) for each character to Step 3, and for each of those
    //rows, also populate the associated dropdown
    //also then needs to move down steps 4 and 5 appropriately!
    //other option is to use scrollbars, but... eh. maybe. see first way first
    private void populateCharacters(int index, CheckState value)
    {

      String character = quillFolders_checklistBox.Items[index].ToString().Trim();
      if (value == CheckState.Checked)
      {

        Control charMouthPanel = new characterToLayerMatch();
        charMouthPanel.Name = character;
        charMouthPanel.Controls.Find("step3_charName", true)[0].Text = character;
        step3Flow.Controls.Add(charMouthPanel);
        //now populate the dropdown
        Layer charLayer = characterLayers[character];
        Character thisChar = new Character();
        thisChar.Name = character;
        thisChar.MainLayer = charLayer;
        chosenCharacters.Add(thisChar.Name, thisChar);
        ComboBox mouthDropdown = ((ComboBox)(charMouthPanel.Controls.Find("step3_mouthDropdown", true)[0]));
        thisChar.mouthOptions.Clear();
        thisChar.MouthDropDown= mouthDropdown;
        populateMouthDropdown(mouthDropdown, charLayer,  0, thisChar);
        updateAudioMatchDropdowns(true, thisChar);
        //also add to all the audiomatch dropdowns (step 5)
      }
      else if (value == CheckState.Unchecked)
      {
        foreach(var charac in chosenCharacters)
        {
          if(charac.Value.Name == character)
          {
            updateAudioMatchDropdowns(false, charac.Value);
            chosenCharacters.Remove(charac.Key);
            break;
          }
        }
        //chosenCharacters.Remove()
        Control rowToDelete = step3Flow.Controls.Find(character, true)[0];
        step3Flow.Controls.Remove(rowToDelete);
        
        //also remove from all the audiomatch dropdowns (step 5)
      }
    }

    //if bool is true, then adding, otherwise removing value
    private void updateAudioMatchDropdowns(bool add, Character character)
    {
      //first get all the rows

      foreach (Control row in step5Flow.Controls.OfType<audioMatch>())
      {
        ComboBox charDropdown = row.Controls.Find("step5_charDropdown", true)[0] as ComboBox;
        if (add)
        {
          charDropdown.Items.Add(character.Name);
        }
        else
        {
          charDropdown.Items.Remove(character.Name);
          if (charDropdown.Text == character.Name)
          {
            charDropdown.Text = "";
          }
        }
      }
    }

    private void populateMouthDropdown(ComboBox mouthDropdown, Layer layer, int offset, Character charac)
    {
      string spaces = new String(' ', offset * 5);
      if (layer.Type.ToString() == "Group" && !layer.Name.ToString().ToLower().Contains("mouth"))
      {
        foreach (Layer child in ((LayerGroup)layer).Children)
        {
          if (child.Type.ToString() == "Group")
          {
            mouthDropdown.Items.Add(spaces + child.Name);
            charac.mouthOptions.Add(spaces + child.Name, child);

            populateMouthDropdown(mouthDropdown, child, offset + 1, charac);
          }
        }
      }
    }

    private void submitButton_MouseClick(object sender, MouseEventArgs e)
    {

      quillErrorProvider.SetError(selectQuill, String.Empty);
      chars_errorProvider.SetError(step2, String.Empty);
      chooseCharacters_errorProvider.SetError(step5, String.Empty);
      chooseMouths_errorProvider.Clear();
      selectAudio_errorProvider.SetError(step4, String.Empty);
      rhub_errorProvider.SetError(submitButton, String.Empty);



      if (sequence == null)
      {
        quillErrorProvider.SetError(selectQuill, "Please select a valid Quill project folder. Should be a folder containing Quill.json, State,json, and Quill.qbin");
        return;
      }

      VisemesGenerator vg = new VisemesGenerator();
        var controls = step5Flow.Controls.OfType<audioMatch>();
        if(controls.Count() == 0)
        {
          
          if(chosenCharacters.Count() == 0)
          {
            chars_errorProvider.SetError(step2, "Please select at least one Quill character");
            return;

          }
          else
          {
            chooseCharacters_errorProvider.SetError(step5, "Please match up each audio file with the appropriate Quill character");
              return;
          }
         
        }

      


      foreach (Control row in step5Flow.Controls.OfType<audioMatch>())
        {
          ComboBox charDropdown = row.Controls.Find("step5_charDropdown", true)[0] as ComboBox;
          string charKey = charDropdown.Text;
          Character currChar = chosenCharacters[charKey];
          Label audioMatch = row.Controls.Find("step5_audioFile", true)[0] as Label;
          currChar.Audio = audios[audioMatch.Text];
          Layer mouthLayer;
          try
          {
            mouthLayer = currChar.mouthOptions[currChar.MouthDropDown.Text];
          }
          catch
          {
            chooseMouths_errorProvider.SetError(step3, "You must have a mouth layer selected for each character");
            return;
          }
          List<LayerGroup> visemesLayers = new List<LayerGroup>();
        //ALSO PUT HERE: MAKE SURE THERE ARE THE PROPER VISEMES-- iterate down the layer
        bool val = vg.SetVisemeMap((LayerGroup)mouthLayer);
          if (vg.SetVisemeMap((LayerGroup)mouthLayer)==false)
          {
            chooseMouths_errorProvider.SetError(step3, "Each mouth layer must contain folder visemes: A, B, C, D, E, F, G, H, X");
            return;
          }
          //maybe add a file dialog here? could even use json and just replace it here, take it out of the method. if that's easier
          //but i'd much rather set location automaticalluy!!!
        vg.generateRhubarbJson(rhubarbExecPath, currChar.Audio.LongAudio, currChar.Audio.LongTxt);
        
          if (!string.IsNullOrWhiteSpace(vg.rhubarbErrors)){
          MessageBox.Show(vg.rhubarbErrors);
        }
          
          //rhub_errorProvider.SetError(submitButton, rhubarbOutput.Item2);
         
          vg.SetVisemeAnims(vg.jsonOutput);
        
          
        }
      string writePath = "";

      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {





        writePath = saveFileDialog.FileName;


      }
      else
      {
        return;
      }

      QuillSequenceWriter.Write(sequence, writePath);
    }


    private void infoLink_Click(object sender, EventArgs e)
    {
      infoLink.LinkVisited = true;

      // Navigate to Google doc
      string url = "https://docs.google.com/document/d/1lObMOR7lBj-foD8X2KHUxbyQAafzqoide3HTnmDBZ-Y/edit?usp=sharing";

      //Should be able to just do the following, but caused errors and wouldn't work on my system. So doing the long way:
      ////System.Diagnostics.Process.Start(url);
      ProcessStartInfo psi = new ProcessStartInfo
      {
        FileName = "cmd",
        RedirectStandardInput = true,
        UseShellExecute = false,
        CreateNoWindow = true
      };

      Process process = new Process { StartInfo = psi };
      process.Start();

      using (StreamWriter sw = process.StandardInput)
      {
        if (sw.BaseStream.CanWrite)
        {
          sw.WriteLine("start " + url);
        }
      }
      process.WaitForExit();
      process.Close();
    }

    private void selectRhubarb_Click(object sender, EventArgs e)
    {
      
      setRhubarb_openFileDialog.Filter = ".exe files(*.exe) | *.exe";
      if (setRhubarb_openFileDialog.ShowDialog() == DialogResult.OK)
      {
        //updated front end form
        string rhubarbExec = setRhubarb_openFileDialog.FileName;
        rhubarbLoc.Text = rhubarbExec;
        rhubarbLoc.ForeColor = System.Drawing.Color.Black;

        //write to settings

        // To write a setting
        Settings1.Default.RhubarbPath = rhubarbExec;
        Settings1.Default.Save(); // Save changes
        //may change this later, but for now, save in form variable
        rhubarbExecPath = rhubarbExec;

      }
    }

    private void quillFolders_checklistBox_ItemCheckEvent(object sender, ItemCheckEventArgs e)
    {
      chars_errorProvider.SetError(step2, String.Empty);
      populateCharacters(e.Index, e.NewValue);
    }

    private void step3panel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void clearMouthErrors(object sender, EventArgs e)
    {
      chooseMouths_errorProvider.Clear();
    }

    private void addAudioButton_Click(object sender, EventArgs e)
    {
      selectAudio_errorProvider.SetError(step4, String.Empty);
      setAudio_openFileDialog.Filter = ".wav files (*.wav)|*.wav|.ogg files (*.ogg)|*.ogg";
      if (setAudio_openFileDialog.ShowDialog() == DialogResult.OK)
      {
        //updated front end form
        string audioPath = setAudio_openFileDialog.FileName;
        Control audioRow = new audioRow();
        string shortenedPath = new DirectoryInfo(audioPath).Name;
        audioRow.Name = shortenedPath;
        
        audioRow.Controls.Find("step4_audioCheckbox", true)[0].Text = shortenedPath; //or maybe just partial path
        //add a click event to the attach icon
        audioRow.Controls.Find("step4_attachButton", true)[0].Click += new System.EventHandler(this.addTxtScript_Click);
        
        audioMatch step5Row = new audioMatch();
        Audio newAudio = new Audio();
        newAudio.ShortAudio = shortenedPath;
        newAudio.LongAudio = audioPath;
        step5Row.Name = shortenedPath;
        step5Row.Controls.Find("step5_audioFile", true)[0].Text = shortenedPath;
        try
        {
          audios.Add(shortenedPath, newAudio);
          step4Flow.Controls.Add(audioRow);
        }
        catch
        {
          selectAudio_errorProvider.SetError(step4, "Audio files must have unique names");
          return;
        }
        ComboBox charsDropdown = step5Row.Controls.Find("step5_charDropdown", true)[0] as ComboBox;
        //var charTest = characterLayers
        //CHECK THESE!!! 
        foreach (var character in quillFolders_checklistBox.CheckedItems)
        {
          charsDropdown.Items.Add(character.ToString().Trim());
        }

        step5Flow.Controls.Add(step5Row);
      }
     

    }
    //make this a checkbox reading event...
    //find all checkboxes within the panel (so all controls of a type)
    //and then if they are checked state, delete the enclosing audioRow control they are in
    //so also figure out how to parent up there
    private void deleteAudio_Click(object sender, EventArgs e)
    {
      //Oh. I think this just goes one level down
      foreach (audioRow row in step4Flow.Controls.OfType<audioRow>())
      {
        CheckBox checkbox = row.Controls.Find("step4_audioCheckbox", true)[0] as CheckBox;
        if (checkbox.Checked)
        {
          var step5audioMatchControls = step5Flow.Controls.OfType<audioMatch>();
          foreach (audioMatch am in step5audioMatchControls)
          {
            Label label = am.Controls.Find("step5_audioFile", true)[0] as Label;
            if(label.Text == checkbox.Text)
            {
              
              audios.Remove(label.Text);
              step5Flow.Controls.Remove(am);
            }
          }
          /*audios.Remove(checkbox.Text);
          Label txtLabel = row.Controls.Find("txtPathLabel", true)[0] as Label;
          */
          step4Flow.Controls.Remove(row);

        }
      }

    }

    //UPDATE THIS: for 
    private void addTxtScript_Click(object sender, EventArgs e)
    {

      setTxt_openFileDialog.Filter = ".txt files (*.txt)|*.txt";
      if (setTxt_openFileDialog.ShowDialog() == DialogResult.OK)
      {
        //updated front end form
        string txtPath = setTxt_openFileDialog.FileName;
        string shortenedPath = new DirectoryInfo(txtPath).Name;
        //LATER, FOR OTHER DICT AS WELL-- add a check if exists, and modify name accordingly (1, 2)

        (sender as Button).Parent.Controls.Find("txtPathLabel", true)[0].Text = shortenedPath;
        string audioKey = (sender as Button).Parent.Controls.Find("step4_audioCheckbox", true)[0].Text;
        audios[audioKey].ShortTxt= shortenedPath;
        audios[audioKey].LongTxt = txtPath;
      }

    }
  }
}
