//
using SharpQuill;
using System;
using System.IO;
using System.Runtime;
using System.Xml.Linq;
using System.Collections.Generic;

/*
 * Purpose of this program: Take a head model and quill and (in a new Quill project), duplicate it to create the named bases for the ARkit blendshapes.
 * Basically, automating the somewhat tedious steps of copying and renaming the head 51 times from within Quill.
 * Note that this script will not modify the original files or folders; it will output a new project folder
 * Expectations for file you're reading in:
 * 1. Should contain only 1 head (as either a single layer, or a single folder), and separate paint layers for right eye and left eye.
 * The expectation is that there are no other nested folders-- if so, the script needs to be modified. Having additional layers is okay, but
 * recommended to keep as bare bones/specifically focused on blendshape creation as possible.
 * 2. If working with a head folder, be sure NOT to transform any of the sub-layers (or to RESET any transforms prior to running script by 
 * first merging layers, resetting the transform, and then re-separating out the layers). You can view transform values in the Quill.json file.
 * This is so the PostLayerCleanup script runs properly (I didn't feel like figuring out how to resolve multiple transforms.
 * It's fine if you've used transforms on a single head layer, on the top-level head folder, or on either of the eyes.
 * 3. Suggested that you do any optimizations prior to running.
 * Big thanks to Joan Charmant for the SharpQuill codebase!!!! (forked)
 */

//Gets user input to choose the read path for the Quill project foler
//this is the path pointing to the original Quill project folder, containing a base head (paint layer OR folder with sub-paint layers), a left eye (paint layer), and a right eye (paint layer)
Console.WriteLine("Please copy-paste the full directory path for the Quill project folder containing your head base folder or layer, and your two eye paint layers. Assuming a Windows system.");
Console.WriteLine("Example structure: C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Face-test");
var readPath = Console.ReadLine();
var sequence = QuillSequenceReader.Read(readPath);
Console.WriteLine();//like to have an extra line for readability
ConfirmReadPathValidity();

/*
 Checks that specified path is a valid directory. If it's not, keeps asking user for new path until it is valid
Then reassigns the value of sequence using valid read path, and uses ConfirmQuillValidity() to ensure it is a valid Quill project folder
*/
void ConfirmReadPathValidity()
{
  while (!Directory.Exists(readPath))
  {
    Console.WriteLine("This is not a valid Directory path. Please enter a new path and press Enter");
    readPath = Console.ReadLine();
  }
  sequence = QuillSequenceReader.Read(readPath);
  ConfirmQuillValidity();
}

/*
 Run from within ConfirmReadPathValidity. Checks if the verified valid read path is a valid Quill project folder
If it's not, asks for user to re-enter (and will return to checking read path validity)
 */
void ConfirmQuillValidity()
{
  while (sequence == null)
  {
    Console.WriteLine("Not a valid Quill project folder.");
    Console.WriteLine("Please ensure that the directory you specified is a Quill project folder containing: Quill.json, Quill.qbin, State.json");
    Console.WriteLine("Re-enter the project directory and press Enter");
    readPath = Console.ReadLine();
    ConfirmReadPathValidity();
  }
}



//used for naming the output file. Change to something different if desired
var suffix = "_blendshapes_str";
var writePath = readPath + suffix;

/*
 * visits the direct children of the Root layer and prints the names (assuming this will be used with the Root layer as the argument
 * returns a list of the top-level children (can be layers or folders)
 * removes any spaces from names, and converts to all lowercase
 */
List<string> LayerName(Layer layer)
{
  List<string> quillLayers = new List<string>();
  if (layer is LayerGroup)
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
    {
      Console.WriteLine(child.Name);
      quillLayers.Add(child.Name);
    }
  }
  return quillLayers;
}

//print out the names of the top-level layers/folders for user to see
Console.WriteLine("Here are the top-level layers or folders under the Root folder in your project: ");

var quillLayers = LayerName(sequence.RootLayer);
Console.WriteLine(); //just like to have an extra line space...

//if Quill file has no layers, exit the application
if(quillLayers.Count == 0)
{
  Console.WriteLine("I'm sorry, this Quill file does not contain any layers, and is not valid for this program.");
  System.Environment.Exit(0);
}

//always convert to lower so it's not case sensitive. And removing any extra spaces
Console.WriteLine("Which of these names is the head layer? Case-Sensitive! Please type the layer/folder name as seen above and press Enter.");
var userAnswer = Console.ReadLine() ?? string.Empty;

userAnswer = userAnswer.Replace(" ", "");
String requestCorrectLayers(List<string> topLevels)
{
  var request = "\nYour answer was invalid. Please choose a name from the following: \n";
  foreach (String str in topLevels)
  {
    request += str + "\n";
  }
  return request;
}

//keep requesting that a name from the actual layer list is given before proceeding

while (!quillLayers.Contains(userAnswer))
{
  Console.WriteLine(requestCorrectLayers(quillLayers));
  userAnswer = Console.ReadLine() ?? string.Empty;
  userAnswer = userAnswer.Replace(" ", "");
}
 
//set basehead variable to the chosen layer in the Quill sequence using the answer given
var baseHead = sequence.RootLayer.FindChild(userAnswer);

//array of all the 50 blendshapes names needed for Unity Live Face Capture. Can adjust names as needed
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
  "mouthStretchRight",
  "tongueOut"
};

//iterate through blendshape names and create a duplicate of head folder/layer with appropriate name
if(baseHead!= null)
{
  for (int i = 0; i < blendshapeNames.Length; i++)
  {
    //needs to reference a new layer each time (otherwise, all new layers have the same name)
    Layer newLayer = baseHead.ShallowCopy(blendshapeNames[i]);
    newLayer.Visible = false; //assuming you will work on each layer separately, so starts off with all of them non-visible
    sequence.InsertLayerAt(newLayer, ""); //putting layers at the root of the existing sequence from the document
  }

  //Writes the modified sequence layer to a new Quill project (renamed using suffixes specified at start)
  QuillSequenceWriter.Write(sequence, writePath);
  Console.WriteLine("New Quill project folder with blendshape starter assets created! See: " + writePath);
}
else
{
  Console.WriteLine("baseHead was null");
}

