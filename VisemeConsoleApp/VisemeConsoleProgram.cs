//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

public class Program
{
  public static void Main(string[] args)
  {
    VisemesGenerator vg = new VisemesGenerator();
    string readPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Rhubarb-Lip-Sync-1.13.0-Windows\\Rhubarb-Lip-Sync-1.13.0-Windows\\rhubarb_samples\\sayaThanking.json";
    vg.readJson(readPath);
  }



}
public class VisemesGenerator
{
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
  public void SetVisemeMap(LayerGroup A, LayerGroup B, LayerGroup C, LayerGroup D, LayerGroup E, LayerGroup F, LayerGroup G, LayerGroup H, LayerGroup X)
{
    visemeMap["A"] = A;
    visemeMap["B"] = B;
    visemeMap["C"] = C;
    visemeMap["D"] = D;
    visemeMap["E"] = E;
    visemeMap["F"] = F;
    visemeMap["G"] = G;
    visemeMap["H"] = H;
    visemeMap["X"] = X;
  }  // find group layers with names-- each must contain at least one paint layer (can be empty and fill out later, I suppose)

  //read the json file in
  //later get from form, but hardcoding for now
  
  public void readWriteVisemes(string readPath, string writePath)

  {
    //comment out later
   //READ

    string visemeJson = File.ReadAllText(readPath);
    dynamic doc = JsonConvert.DeserializeObject(visemeJson);
    dynamic mouthCues = doc["mouthCues"]; //based off how it's organized by Rhubarb 
    foreach (var item in mouthCues)
    {
      Console.WriteLine(item);
    }
  
  }


  //errors: must have a layer selected for each one (though could eliminate the extra ones, I suppose); each layer must be a group layer. Ideally want a paint layer but could add after, I suppose



  //using the json file (hardcode for now), convert to seconds, then use to 

}


