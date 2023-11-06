using System.Diagnostics;
using SharpQuill;
using Newtonsoft.Json;
using System.Configuration;
namespace VisemesWinFormsApp
{
  public partial class VisemesForQuillForm : Form
  {
    private string rhubarbExecPath;


    public VisemesForQuillForm()
    {
      InitializeComponent();
      //see if Rhubarb exec location is already set. If so, prepopulate form and data
      //load config file
      // Load the configuration file
      // To read a setting
      string rhubarbPath = Settings1.Default.RhubarbPath;
      if (rhubarbPath == null || rhubarbPath =="")
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
        rhubarbLoc.Text = "ERROR";
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
      public void generateRhubarbJson(string rhubarbExecPath, string audioPath, string optionalTxtPath = "")
      {
  
        Process rhubarbCli = new Process();
        //the exec path is rhubarbExecPath, should be set
        //string rhubarbExecPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb.exe";//complete path to rhubarb executable-- I think it should be folder that contains .exe, double check -- basically, where you need to be "cd" into to run
        
        string audioFileName = new DirectoryInfo(audioPath).Name;
        string jsonOutputPath = rhubarbExecPath + "\\jsonOutput\\" + audioFileName; //allow user to choose where to save/output-- save as, and that will run it-- give errors if not selected, etc
        rhubarbCli.StartInfo.FileName = rhubarbExecPath;
        //IF textScriptPath is null, then you omit -d + textScriptPath part-- change later
        if(optionalTxtPath == "")
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
  

        }
        catch (Exception e)
        {
          MessageBox.Show("Error: " + e.Message);
        }
        /*
        rhubarbCli.Start();

        string errors = rhubarbCli.StandardError.ReadToEnd();

        if (!string.IsNullOrWhiteSpace(errors))
        {
          Console.WriteLine("Error Output:\n" + errors);
        }*/
      }

      //have a dictionary that maps layers to visemes
      private Dictionary<string, LayerGroup> visemeMap = new Dictionary<string, LayerGroup>();

      public void SetAudioOffset(Layer soundLayer, Layer mainMouthLayer)
      {
        offset = soundLayer.Animation.Keys.Offset[0].Time;

        OffsetHelperWalkdown(mainMouthLayer);
      }

      public void OffsetHelperWalkdown(Layer layer)
      {
        layer.Animation.Keys.Offset[0].Time = offset;
        foreach (Keyframe<bool> visKey in layer.Animation.Keys.Visibility)
        {
          //layer.Animation.Keys.Visibility[0].Time = offset;
          visKey.Time += offset;
        }
        if (layer.Type.ToString() == "Group")
        {
          foreach (Layer child in ((LayerGroup)layer).Children)
          {
            OffsetHelperWalkdown(child);
          }
        }
      }
      //for form: set when enter. try to autofill when possible-- so like, have a dropdown, set dropdown value to letter if it exists (do lower case and upper case)
      public void SetVisemeMap(LayerGroup root)
      {
        List<LayerGroup> groupLayers = new List<LayerGroup>();
        root.GetGroupChildren(groupLayers);
        foreach (var child in groupLayers)
        {
          //Console.WriteLine(child.Name);
          foreach (var item in visemes)
          {
            if (child.Name == item)
            {
              visemeMap[item] = child;
              //Console.WriteLine(item);
            }
          }
        }

      }  // find group layers with names-- each must contain at least one paint layer (can be empty and fill out later, I suppose)

      //read the json file in
      //later get from form, but hardcoding for now

      public void SetVisemeAnims(string readPath)

      {

        string startingViseme = "";
        string visemeJson = File.ReadAllText(readPath);//reading rhubarb output
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
