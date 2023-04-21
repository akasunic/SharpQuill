//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;

var readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_two-folders";
//some sample file paths: "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder"
var suffix = "_blendshapes";
//default, change to whatever you want
var writePath = readPath + suffix;
String headLayer = "Face-base"; //set this to however you named your base head layer or folder


//first, get access to the layer using the read functions
var sequence = QuillSequenceReader.Read(readPath);

//if needed, get the proper layer name before proceeding
void LayerName(Layer layer)
{
  if (layer is LayerGroup)
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
      Console.WriteLine(child.Name); 
  }
}


//comment out if not needed
LayerName(sequence.RootLayer);
//so it's Face-base in this case-- will want to start using a standard naming convention in general, will make it easier


var baseHead = sequence.RootLayer.FindChild(headLayer);

string[] blendshapeNames =
{
  "browInnerUp",
  "browDownLeft",
  "browDownRight",
  "browOuterUpLeft",
  "browOuterUpRight",
  "eyeLookUpLeft",
  "eyeLookUpRight",
  "eyeLookDownLeft",
  "eyeLookDownRight",
  "eyeLookInLeft",
  "eyeLookInRight",
  "eyeLookOutLeft",
  "eyeLookOutRight",
  "eyeBlinkLeft",
  "eyeBlinkRight",
  "eyeSquintRight",
  "eyeSquintLeft",
  "eyeWideLeft",
  "eyeWideRight",
  "cheekPuff",
  "cheekSquintLeft",
  "cheekSquintRight",
  "noseSneerLeft",
  "noseSneerRight",
  "jawOpen",
  "jawForward",
  "jawLeft",
  "jawRight",
  "mouthFunnel",
  "mouthPucker",
  "mouthLeft",
  "mouthRight",
  "mouthRollUpper",
  "mouthRollLower",
  "mouthShrugUpper",
  "mouthShrugLower",
  "mouthSmileLeft",
  "mouthSmileRight",
  "mouthFrownLeft",
  "mouthFrownRight",
  "mouthDimpleLeft",
  "mouthDimpleRight",
  "mouthUpperUpLeft",
  "mouthUpperUpRight",
  "mouthLowerDownLeft",
  "mouthLowerDownRight",
  "mouthPressLeft",
  "mouthPressRight",
  "mouthStretchLeft",
  "mouthStretchRight"
};

for (int i = 0; i < blendshapeNames.Length; i++)
{
  //baseHead.Name = blendshapeNames[i]; //renaming layer or layer group to appropriate blendshape
    Layer newLayer = baseHead.DeepCopy(blendshapeNames[i]);
    newLayer.Visible = false;
  sequence.InsertLayerAt(newLayer, ""); //putting layers at the root
  
}

//then, insert that layer into the document. CAN YOU NAME IT THOUGH??? TRY THAT NEXT
//sequence.InsertLayerAt(baseHead, "");
QuillSequenceWriter.Write(sequence, writePath);
