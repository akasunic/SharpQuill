using SharpQuill;
using System.IO;

//*****************WHERE I'm CURRENTLY STUCK************************
//********So, even when I just literally read and write the document, it's generating an empty file. WHICH IS A PROBLEM OF COURSE. It has bounding box data etc
//BUT each layer has a beginnning drawing of BBox 0^X6. And it seems that because this is present, it doesn't generate
//BUT THEN SHOULDNT IT HAVE WORKED TO MAKE SURE WE DIDN"T DRAW THOSE 0 BOXES??? it seems it should have
//SO it could be an issue with the file you're working on. In fact, try this using a non modified file to see, that will give you some insight...
//OKAY NO SO It is still generating an empty stroke file--
//SO HOPEFUL BIT IS: MUST BE SOMETHING ELSE MORE SOLVABLE!!! THOUGH ALSO< DID YOU MESS WITH ANY SHARP QUIlL SETTINGS??? TEST IT!!!
//MAKE SURE PROGRAM.CS STILL RUNS!!!
////***** SHIT!!! I DID SOMETHING. NEED TO LOOK AT ALL CHANGES TO ORIGINAL. BC NOW PREVIOUS ONE DOESN"'t WORK EITHER!!!
///FIXED LAYERPAINT ISSUE!!! DON"T MESS WITH THOSE BOOLS DUMMY
var readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder";
//some sample file paths: "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder_blendshapes"
//whatever it is, needs to be the reference to the Quill folder that was modified by original script (test it first to check)
var suffix = "_layersTidied";
//default, change to whatever you want
var writePath = readPath + suffix;

//I really want to do like, sequence.RootLayer.children, you know??
// Create the standard default scene but without any paint layer. (?)

var newSequence = Sequence.CreateDefault();
var readSequence = QuillSequenceReader.Read(readPath);
List<Layer> layers = new List<Layer>();
void FlattenLayers(Layer layer)
{
  
  if (layer is LayerGroup) //will be true for Root
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
    {
      if (child is LayerGroup)
      {
        break;//make an empty paint layer with the name of the group
        var path = "/" + child.Name; 
        LayerPaint flattenedLayer = new LayerPaint(child.Name);
        //var allStrokes = new List<Stroke>();
        
    

        //iterate through all the children of this child--
        //Use: Drawings.Add(new Drawing()); see LayerPaint.cs
        foreach (Layer grandchild in ((LayerGroup)child).Children) 
        {
          Console.WriteLine(grandchild.Name);
          //going to assume these are now all just plain paint layers
          var listOfDrawings = ((LayerPaint)grandchild).Drawings;
          //Console.Write(listOfDrawings);
          var x = 0;
          foreach (Drawing drawing in listOfDrawings) {
            //make a clone of the drawing
            flattenedLayer.Drawings.Add(drawing.Clone());

        
          }

        }
 
        flattenedLayer.Visible = false; //otherwise might be too many visible at once, performance issues
        newSequence.InsertLayerAt(flattenedLayer, "");
      }
      //if it's already a single paint layer, want to make sure that is added to the Quill file
      else
      {
        //Layer newLayer = child.DeepCopy(child.Name);//testing using a clone, bc for some reason this also empty of strokes??
        foreach(Drawing drawing in ((LayerPaint)child).Drawings)
        {
          //if bounding box of drawing is 00000, then remove from the list-- COME BACK TO THIS LATER!!!!
         // ((LayerPaint)child).Drawings
        }
        layers.Add(child);
        //readSequence.InsertLayerAt(child, "");//CHANGE BACK TO NEW LATER??
      }
    }
  }
  
}


//FlattenLayers(readSequence.RootLayer);
/*foreach(Layer lay in layers)
{
  readSequence.InsertLayerAt(lay, ""); //OKAY SOMETHING GOING ON!!! BC EVEN WITH NOTHING CHANGING IT'S DELETING ALL STROKE DATA!!!
}*/
QuillSequenceWriter.Write(readSequence, writePath);
