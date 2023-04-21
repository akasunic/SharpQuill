//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;

var readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder";
//some sample file paths: "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder"
var suffix = "_blendshapes";
//default, change to whatever you want
var writePath = readPath + suffix;


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


//make a deep copy of the layer???


LayerName(sequence.RootLayer);
//so it's Face-base in this case-- will want to start using a standard naming convention
//note that this script is for folder?? 

var baseHead = sequence.RootLayer.FindChild("Face-base");
//Attempting to make two new copies of a layer and give them new names???

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
