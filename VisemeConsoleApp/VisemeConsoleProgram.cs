//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using System.Security.Cryptography;

public class Program
{
  public static void Main(string[] args)
  {
    VisemesGenerator vg = new VisemesGenerator();
    string jsonReadPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\sayaThanking.json";
    string quillReadPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Viseme-test";
    string writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Viseme-test_EDITED";
    Sequence sequence = QuillSequenceReader.Read(quillReadPath);
    LayerGroup root = sequence.RootLayer;
    vg.SetVisemeMap(root);
    vg.SetVisemeAnims(jsonReadPath);
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

  //have a dictionary that maps layers to visemes
  private Dictionary<string, LayerGroup> visemeMap = new Dictionary<string, LayerGroup>();

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
    string visemeJson = File.ReadAllText(readPath);
    dynamic doc = JsonConvert.DeserializeObject(visemeJson);
    dynamic mouthCues = doc.mouthCues; //based off how it's organized by Rhubarb 
    foreach (var item in mouthCues)
    {
      //check at each one, just in case they're ever out of time order (default is that they're in time order)
      if((int)(item.start * timeConversion) == 0)
      {
        startingViseme = item.value;
      }
      Keyframe<bool> startVis = new SharpQuill.Keyframe<bool>((int)(item.start * timeConversion), true, Interpolation.None);//add a visibility key frame
      Keyframe<bool> endVis = new SharpQuill.Keyframe<bool>((int)(item.end * timeConversion), false, Interpolation.None);
     
      
      visemeMap[(string)item.value].Animation.Keys.Visibility.Add(startVis);
      visemeMap[(string)item.value].Animation.Keys.Visibility.Add(endVis);
 
    }
    //now go through each layer, see earliest visibility start, and if greater than 0, set a visibility start key frame to 0
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


