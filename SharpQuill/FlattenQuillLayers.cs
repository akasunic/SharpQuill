using SharpQuill;
using System.IO;

/*
 * This script is not well-named... It can be used to flatten layers in a Quill document, specifically intended for a blendshape workflow
 * That is, it expects as input a Quill project where each blendshape is a folder (LayerGroup), each of which contains paint layers
 * Not set up to handle nested folders!
 * Output: a Quill project that contains only paint layers for each blendshape (folder aka LayerGroup)
 * Note that this script will not modify the original files or folders; it will output a new project folder
 * 
 * 
 * But this script could technically be used for any Quill projects with folders that contain only paint layers (not sub-folders) that you want to flatten programatically
 * It is NOT necessary to run this for blendshape projects if blendshapes were already individual paint layers
 * But it may sometimes be easier to work with folders, whereas the final output should be individual paint layers, so here we are
 * 
 * Known issue: the paint layers under each folder must NOT have transforms on them. The eyes and the top level folders may.
 * If you forgot this while creating, and have transforms on individual paint layers, it would be easier to just flatten layers manually, as I've not accounted for this in this code!
 * This script re-uses some code used in blendshape starter file script (Program.cs, under ConsoleApp1/CreateBlendshapesStarter), but I am lazy so copied and pasted relevant code when needed...
 */

//get the location of the project you want to create a flattened version of; check for path and project validity
Console.WriteLine("Copy-paste the full directory path for the Quill project folder. \nThis project should have Quill folders (i.e. for blendshapes) that need to be flattened into single paint layers.\nProject cannot have nested folders.");
Console.WriteLine("Example structure: C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Face-test_blendshapes");
var readPath = Console.ReadLine();
var readSequence = QuillSequenceReader.Read(readPath); //code line direct from Joan Charmant's example
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
  readSequence = QuillSequenceReader.Read(readPath);
  ConfirmQuillValidity();
}

/*
 Run from within ConfirmReadPathValidity. Checks if the verified valid read path is a valid Quill project folder
If it's not, asks for user to re-enter (and will return to checking read path validity)
 */
void ConfirmQuillValidity()
{
  while (readSequence == null)
  {
    Console.WriteLine("Not a valid Quill project folder.");
    Console.WriteLine("Please ensure that the directory you specified is a Quill project folder containing: Quill.json, Quill.qbin, State.json");
    Console.WriteLine("Re-enter the project directory and press Enter");
    readPath = Console.ReadLine();
    ConfirmReadPathValidity();
  }
}

var suffix = "_layersTidied";
//default, change to whatever you want
var writePath = readPath + suffix;

// From Joan Charmant's example: Create the standard default scene but without any paint layers
var newSequence = Sequence.CreateDefault();

/*
 When passed a root layer, this method then goes through each top-level layer/folder. If it's a folder (aka a LayerGroup),
create a flattened paint layer, set transform and name equivalent to folder (aka LayerGroup)
and then add drawing data from each paint layer from original folder structure
by iteratively cloning the drawing data from the first drawing of each layer, getting all the strokes,
iteratively adding the strokes to the data of the new data and updating the bounding box of the new layer to include each stroke's bounding box
assigning the new layer's drawing's strokes, bounding box and frames after you have iteratively visited all info from the original layers.
This method also adds any original paint layers and all updated (flattened) paint layers to a new Quill sequence
 */
void FlattenLayers(Layer layer)
{
  if (layer is LayerGroup) //will be true for Root, so going down one level
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
    {
      //if it's a LayerGroup, then you want to flatten the paint layers into a single paint layer before adding to the new sequence
      if (child is LayerGroup)
      {
        LayerPaint flattenedLayer = new LayerPaint(child.Name);
        //Get transform of child [the group layer] and set the flattenedLayer to the same Transform
        //Note that this does nothing with the sub-layers in that group layer-- those need to NOT have been transformed!
        //If they have, then just skip this script and flatten layers manually in Quill
        //(Note: can look into Quill.json OR just run the script and see if it looks wonky)
        flattenedLayer.Transform = child.Transform;

        //A note about BoundingBox: had to instantiate it separately from a drawing, and add it in at the end
        //Otherwise it was not setting up properly
        //this will be the bounding box of the new flattened layer
        BoundingBox newBox = new BoundingBox(0,0,0,0,0,0);

        //there can only be one drawing per frame, so one drawing total in the JSON file per LayerPaint
        flattenedLayer.Drawings.Add(new Drawing());
        //instantiate empty list of strokes that you can then iteratively add to
        List<Stroke> layerStrokes = new List<Stroke>();

        //iterate through all paint layers contained in the folder (LayerGroup)
        foreach (Layer grandchild in ((LayerGroup)child).Children)
        {
          
          //Assumes that there are NOT nested folders, so these are truly all LayerPaints

          //clone the Drawing data from this paint layer, and then get all the strokes
          Drawing drawingToCopy = ((LayerPaint)grandchild).Drawings[0];
          List<Stroke> strokesCopy = drawingToCopy.Data.Clone().Strokes;

          //iterate through strokes in this copy, and add them to the list of strokes
          //you will later also
          //as each stroke is added, also update the bounding box of the drawing (tried using bounding box of copied drawing directly, but wasn't working)
          foreach (Stroke stroke in strokesCopy)
          {
            layerStrokes.Add(stroke);
            newBox.Expand(stroke.BoundingBox);
          }
        }

        //NOW you can update the strokes and bounding box for the new flattened layer
        flattenedLayer.Drawings[0].Data.Strokes = layerStrokes;
        flattenedLayer.Drawings[0].BoundingBox = newBox;

        //Also need to add 0 to Frames, otherwise it was defaulting to null and causing errors
        ((LayerPaint)flattenedLayer).Frames = new List<int> { 0}; 
        flattenedLayer.Visible = true; //when exporting for Maya, you'll want them all visible
        newSequence.InsertLayerAt(flattenedLayer, "");
      }

      //if it's already a single paint layer (e.g., the two eye layers, or any LayerGroups you've already flattened manually), add it directly to sequence
      {

        newSequence.InsertLayerAt(child, "");
      }
    }
  }
}

FlattenLayers(readSequence.RootLayer);


QuillSequenceWriter.Write(newSequence, writePath);
Console.WriteLine("New Quill project folder with flattened layers created! See: " + writePath);
