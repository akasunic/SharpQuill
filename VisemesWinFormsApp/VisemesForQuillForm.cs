using System.Diagnostics;
using SharpQuill;
using Newtonsoft.Json;
using System.Configuration;
namespace VisemesWinFormsApp
{
  public partial class VisemesForQuillForm : Form
  {
    private string rhubarbExecPath;
    private string? quillPath;
    Sequence sequence;
    private Dictionary<string, Layer> characterLayers = new Dictionary<string, Layer>();
    private Dictionary<string, Layer> characterMouths = new Dictionary<string, Layer>();

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
          //TO DO: error provider for Quill
          //quillErrorProvider.SetError(readPathChoice, "Not a valid Quill project folder. Should be a folder containing Quill.json, State,json, Quill.qbin");
        }
        else
        {
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
      /*else if (layer.Type.ToString() == "Paint")
      {
        dropdown.Items.Add(layer.Name);
      }*/
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
        ComboBox mouthDropdown = ((ComboBox)(charMouthPanel.Controls.Find("step3_mouthDropdown", true)[0]));

        populateMouthDropdown(mouthDropdown, charLayer, 0);
        updateAudioMatchDropdowns(true, character);
        //also add to all the audiomatch dropdowns (step 5)
      }
      else if (value == CheckState.Unchecked)
      {
        Control rowToDelete = step3Flow.Controls.Find(character, true)[0];
        step3Flow.Controls.Remove(rowToDelete);
        updateAudioMatchDropdowns(false, character);
        //also remove from all the audiomatch dropdowns (step 5)
      }
    }

    //if bool is true, then adding, otherwise removing value
    private void updateAudioMatchDropdowns(bool add, string charName)
    {
      //first get all the rows
      
      foreach (Control row in step5Flow.Controls.OfType<audioMatch>())
      {
        ComboBox charDropdown = row.Controls.Find("step5_charDropdown", true)[0] as ComboBox;
        if (add)
        {
          charDropdown.Items.Add(charName);
        }
        else
        {
          charDropdown.Items.Remove(charName);
        }
      }
    }

    private void populateMouthDropdown(ComboBox mouthDropdown, Layer layer, int offset)
    {
      string spaces = new String(' ', offset * 5);
      if (layer.Type.ToString() == "Group" && !layer.Name.ToString().ToLower().Contains("mouth"))
      {
        foreach (Layer child in ((LayerGroup)layer).Children)
        {
          if (child.Type.ToString() == "Group")
          {
            mouthDropdown.Items.Add(spaces + child.Name);
            populateMouthDropdown(mouthDropdown, child, offset + 1);
          }
        }
      }
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
      else
      {
        //BUILD OUT MORE LATER
        //rhubarbLoc.Text = "ERROR";
      }
    }

    private void quillFolders_checklistBox_ItemCheckEvent(object sender, ItemCheckEventArgs e)
    {
      populateCharacters(e.Index, e.NewValue);
    }

    private void step3panel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void addAudioButton_Click(object sender, EventArgs e)
    {
      if (setAudio_openFileDialog.ShowDialog() == DialogResult.OK)
      {
        //updated front end form
        string audioPath = setAudio_openFileDialog.FileName;
        Control audioRow = new audioRow();
        audioRow.Name = audioPath;
        audioRow.Controls.Find("step4_audioCheckbox", true)[0].Text = audioPath; //or maybe just partial path
        //add a click event to the attach icon
        audioRow.Controls.Find("step4_attachButton", true)[0].Click += new System.EventHandler(this.addTxtScript_Click);
        step4Flow.Controls.Add(audioRow);
        audioMatch step5Row = new audioMatch();
        step5Row.Name = audioPath;
        step5Row.Controls.Find("step5_audioFile", true)[0].Text = audioPath;
        ComboBox charsDropdown = step5Row.Controls.Find("step5_charDropdown", true)[0] as ComboBox;
        //var charTest = characterLayers
          //CHECK THESE!!! 
        foreach(var character in quillFolders_checklistBox.CheckedItems)
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
        if (checkbox.Checked) { 
          step4Flow.Controls.Remove(row);
        }
      }

    }

    //UPDATE THIS: for 
    private void addTxtScript_Click(object sender, EventArgs e)
    {
      if (setTxt_openFileDialog.ShowDialog() == DialogResult.OK)
      {
        //updated front end form
        string txtPath = setTxt_openFileDialog.FileName;
        
        (sender as Button).Parent.Controls.Find("txtPathLabel", true)[0].Text = txtPath;

      }

    }
    /*
     * Not sure if this is bad practice, but keeping the class here, in the same file. Maybe it is. Idk.
    Maybe I'll change later.
     */
    public class VisemesGenerator
    {

      public int timeConversion = 12600;
      public int offset;//this is the offset for the audio file in Quill. Apply offset to mouth layer
                        //may not be needed
                        //have a dictionary that maps layers to visemes
      private Dictionary<string, LayerGroup> visemeMap = new Dictionary<string, LayerGroup>();


      public List<string> visemes = new List<string>
      {
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "X"
      };

      //making sure I can properly run rhubarb from here-- put in a winforms later
      //generate rhubarb json! think about-- should that be a variable of the instance? yeah, maybe
      public String generateRhubarbJson(string rhubarbExecPath, string audioPath, string optionalTxtPath = "")
      {

        Process rhubarbCli = new Process();
        //the exec path is rhubarbExecPath, should be set
        //string rhubarbExecPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb.exe";//complete path to rhubarb executable-- I think it should be folder that contains .exe, double check -- basically, where you need to be "cd" into to run

        string audioFileName = new DirectoryInfo(audioPath).Name;
        string jsonOutputPath = rhubarbExecPath + "\\jsonOutput\\" + audioFileName; //allow user to choose where to save/output-- save as, and that will run it-- give errors if not selected, etc
        rhubarbCli.StartInfo.FileName = rhubarbExecPath;
        //IF textScriptPath is null, then you omit -d + textScriptPath part-- change later
        if (optionalTxtPath == "")
        {
          rhubarbCli.StartInfo.Arguments = "-o " + jsonOutputPath + " -f json " + audioPath;
        }
        else
        {
          rhubarbCli.StartInfo.Arguments = "-o " + jsonOutputPath + " -f json -d " + optionalTxtPath + " " + audioPath;

        }

        rhubarbCli.StartInfo.RedirectStandardError = true;
        rhubarbCli.StartInfo.UseShellExecute = false;
        rhubarbCli.StartInfo.CreateNoWindow = true;


        try
        {
          rhubarbCli.Start();
          return jsonOutputPath;

        }
        catch (Exception e)
        {
          MessageBox.Show("Error: " + e.Message);
          return "";
        }
        /*
        rhubarbCli.Start();

        string errors = rhubarbCli.StandardError.ReadToEnd();

        if (!string.IsNullOrWhiteSpace(errors))
        {
          Console.WriteLine("Error Output:\n" + errors);
        }*/
      }

      //for form: set when enter. try to autofill when possible-- so like, have a dropdown, set dropdown value to letter if it exists (do lower case and upper case)
      public void SetVisemeMap(LayerGroup mouthRoot)
      {
        List<LayerGroup> groupLayers = new List<LayerGroup>();
        mouthRoot.GetGroupChildren(groupLayers);
        foreach (var child in groupLayers)
        {
          //Console.WriteLine(child.Name);
          foreach (var item in visemes)
          {
            if (child.Name.ToLower().Trim() == item.ToLower())
            {
              visemeMap[item] = child;
              //Console.WriteLine(item);
            }
          }
        }

      }  // find group layers with names-- each must contain at least one paint layer (can be empty and fill out later, I suppose)

      //read the json file in
      //later get from form, but hardcoding for now

      public void SetVisemeAnims(string jsonPath)

      {

        string startingViseme = "";
        string visemeJson = File.ReadAllText(jsonPath);//reading rhubarb output
        dynamic doc = JsonConvert.DeserializeObject(visemeJson);
        dynamic mouthCues = doc.mouthCues; //based off how it's organized by Rhubarb
        float endTime = 0;
        string lastViseme = "";
        foreach (var item in mouthCues)
        {
          //Console.WriteLine("item.value: " + item.value + "; item.end: " + item.end);//check at each one, just in case they're ever out of time order (default is that they're in time order)
          if ((int)(item.start * timeConversion) == 0)
          {
            startingViseme = item.value;
          }
          if ((float)(item.end) > endTime)
          {
            endTime = item.end;
            lastViseme = item.value;
            //Console.WriteLine("current endtine: " + endTime + "; current last viseme: " + lastViseme);
          }

          Keyframe<bool> startVis = new SharpQuill.Keyframe<bool>((int)(item.start * timeConversion), true, Interpolation.None);//add a visibility key frame
          Keyframe<bool> endVis = new SharpQuill.Keyframe<bool>((int)(item.end * timeConversion), false, Interpolation.None);


          visemeMap[(string)item.value].Animation.Keys.Visibility.Add(startVis);
          visemeMap[(string)item.value].Animation.Keys.Visibility.Add(endVis);

        }
        //Console.WriteLine("end of visemes json is: " + endTime*timeConversion + " for viseme: " + lastViseme);
        //set visibility animation for the end time, to start the resting mouth position
        Keyframe<bool> restAtEnd = new Keyframe<bool>((int)(endTime * timeConversion), true, Interpolation.None);
        //first see if a key with this value exists\\
        bool seeIfIncl = false;
        foreach (var item in visemeMap["X"].Animation.Keys.Visibility)

        {
          //Console.WriteLine("time is: " + item.Time);
          if ((int)item.Time == (int)restAtEnd.Time)
          {
            //Console.WriteLine("end time is: " + item.Time);
            item.Value = true;
            seeIfIncl = true;
          }
        }
        if (seeIfIncl == false)
        {
          visemeMap["X"].Animation.Keys.Visibility.Add(restAtEnd);
        }

        //now go through each layer, see earliest visibility start, and if greater than 0, set a visibility start key frame to 0
        //um i should do this more efficiently. but like, i like to think in steps so... idk
        foreach (var key in visemeMap.Keys)
        {
          visemeMap[key].Visible = true;
          if (key != startingViseme)
          {
            List<Keyframe<bool>> visibilityKeys = visemeMap[key].Animation.Keys.Visibility;

            //would like to just do the first item in visibility keys, but being safe in case they could ever be out of order
            for (int i = 0; i < visemeMap[key].Animation.Keys.Visibility.Count; i++)
            {
              if (visemeMap[key].Animation.Keys.Visibility[i].Time == 0)
              {
                visemeMap[key].Animation.Keys.Visibility[i].Value = false;
              }
            }
          }
        }
      }
    }


  }
}

