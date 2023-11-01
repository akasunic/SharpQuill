//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;


//STEPS NEEDED IN FORM!!
/*//PRE-STEP!!! Still didnt change the offset thing for audio-- should do that [just commenting out for now, that's fine]
 * 1. select quill project containing characters (and mouths!) you want to animate
 * 2. populate dropdown with layers-- use formatting (and be able to reverse formatting?? or map to real layer?) for choosing Characters involved in dialogue
 * 
 * LATER: helper tool, select mouth layers, will prepopulate with a folder at the same level containing a copy of mouth, contained in folders X A B C etc* 
 3. For each character, separate dropdown to select the top level mouth layer
4. then i guess to the rhubarb and viseme matcher at once, per your picture? watch out for danger of overwriting files-- oh, but it's fine if you use save as, so nvm*
so basically, select all your audio files. and then for each one, save the output json, and choose the character to apply it to.

 */
public class Program
{
  public static void Main(string[] args)
  {
    //EDIT CODE!!!!!!! VisemesGenerator should take arguments, jsonReadPath, quillReadPath, etc.
    VisemesGenerator vg = new VisemesGenerator();
    string jsonReadPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\sayaThanking.json";
    string quillReadPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Viseme-test";
    string writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Viseme-test_EDITED";
    vg.deleteLaterTestingRhubarbCLI();
    Sequence sequence = QuillSequenceReader.Read(quillReadPath);
    LayerGroup root = sequence.RootLayer;
    LayerGroup head = (LayerGroup)(sequence.RootLayer.FindChild("Head"));
    LayerGroup mouth = (LayerGroup )head.FindChild("Mouth");
    Layer sound = root.FindChild("saya_thanking_uncleBob(mp3).mp3");
    //vg.SetAudioOffset(sound, mouth);
    vg.SetVisemeMap(root);
    vg.SetVisemeAnims(jsonReadPath);
    vg.SetAudioOffset(sound, mouth);
    QuillSequenceWriter.Write(sequence, writePath);
    
  }
  //SOME THOUGHTS
  //what about auto-generating for multiple characters/audio clips? can you also choose your audio file there, bc then you can get the offset of it?
  //Need to have a dropdown for top level character/container for mouth
  //or like, how many characters are you animating? be able to put all the characters, all the audio in there

}
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
  public void deleteLaterTestingRhubarbCLI()
  {
    Console.WriteLine("in rhubarb");
    Process rhubarbCli = new Process();
    //so these files all chosen via FileDialog in WinForms

    //NOTE: later update to save the exec path so you don't have to save each time
    //make a note of the current version-- may not work with most recent-- could be updated to most recent, though
    //When the application starts, check the registry for the saved Rhubarb executable path.If it exists, prepopulate the UI element with this path.

    //Allow users to change the Rhubarb executable path in your application, and when they do, update the registry with the new path.


    //sing Microsoft.Win32;

    // Write a value to the registry
    //Registry.SetValue(@"HKEY_CURRENT_USER\Software\YourAppName", "RhubarbPath", "C:\Path\to\Rhubarb.exe");

    // Read a value from the registry
    //string rhubarbPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\YourAppName", "RhubarbPath", "") as string;


    string rhubarbExecPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb.exe";//complete path to rhubarb executable-- I think it should be folder that contains .exe, double check -- basically, where you need to be "cd" into to run
    string? audioPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\saya_thanking_uncleBob_ogg.ogg";//full path to audio file-- must be .wav, .ogg, etc (see rhubarb rules)
    string? textScriptPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\sayaThankingScript.txt";// full path to text script-- this is optional
    string? jsonOutputPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\newoutput.json"; //allow user to choose where to save/output-- save as, and that will run it-- give errors if not selected, etc
    rhubarbCli.StartInfo.FileName = rhubarbExecPath;
    //IF textScriptPath is null, then you omit -d + textScriptPath part-- change later
    rhubarbCli.StartInfo.Arguments = "-o " + jsonOutputPath + " -f json -d " + textScriptPath + " " + audioPath;
    rhubarbCli.StartInfo.RedirectStandardError = true;
    rhubarbCli.StartInfo.UseShellExecute = false;
    rhubarbCli.StartInfo.CreateNoWindow = true;

    try
    {
      rhubarbCli.Start();
      Console.WriteLine("running rhubarb");

    }
    catch (Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
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
      foreach(Layer child in ((LayerGroup)layer).Children)
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
    foreach(var child in groupLayers)
    {
      //Console.WriteLine(child.Name);
      foreach(var item in visemes)
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
    //comment out later
    //READ


    string startingViseme = "";
    string visemeJson = File.ReadAllText(readPath);//reading rhubarb output
    dynamic doc = JsonConvert.DeserializeObject(visemeJson);
    dynamic mouthCues = doc.mouthCues; //based off how it's organized by Rhubarb
    float endTime = 0;
    string lastViseme = "";
    foreach (var item in mouthCues)
    {
      //Console.WriteLine("item.value: " + item.value + "; item.end: " + item.end);//check at each one, just in case they're ever out of time order (default is that they're in time order)
      if((int)(item.start * timeConversion) == 0)
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
    Keyframe<bool> restAtEnd = new Keyframe<bool>((int)(endTime*timeConversion), true, Interpolation.None);
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


  //errors: must have a layer selected for each one (though could eliminate the extra ones, I suppose); each layer must be a group layer. Ideally want a paint layer but could add after, I suppose



  //using the json file (hardcode for now), convert to seconds, then use to 

}


