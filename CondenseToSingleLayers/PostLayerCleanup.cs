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
var readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder_blendshapes";
//some sample file paths: "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder_blendshapes"
//whatever it is, needs to be the reference to the Quill folder that was modified by original script (test it first to check)
var suffix = "_layersTidied";
//default, change to whatever you want
var writePath = readPath + suffix;

//I really want to do like, sequence.RootLayer.children, you know??
// Create the standard default scene but without any paint layer. (?)

var newSequence = Sequence.CreateDefault();
var readSequence = QuillSequenceReader.Read(readPath);

void FlattenLayers(Layer layer)
{
  
  if (layer is LayerGroup) //will be true for Root
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
    {
      if (child is LayerGroup)
      {

        //var path = "/" + child.Name; 
        LayerPaint flattenedLayer = new LayerPaint(child.Name);
        BoundingBox newBox = new BoundingBox(0,0,0,0,0,0);
        flattenedLayer.Drawings.Add(new Drawing());
        List<Stroke> layerStrokes = new List<Stroke>();
       
        //var allStrokes = new List<Stroke>();
        //WAAHHHHHH IT'S NOT 


        //iterate through all the children of this child--
        //Use: Drawings.Add(new Drawing()); see LayerPaint.cs
        foreach (Layer grandchild in ((LayerGroup)child).Children)
        {
          Console.WriteLine(grandchild.Name);
          //going to assume these are now all just plain paint layers
          Drawing drawingToCopy = ((LayerPaint)grandchild).Drawings[0];
          List<Stroke> strokesCopy = drawingToCopy.Data.Clone().Strokes;
          //Console.Write(listOfDrawings);
          
          
            //add that drawing to the big drawing list
            //NO THIS WILL NOT WORK BECAUSE YOU SHOULD ONLY HAVE ONE DRAWING FOR A FRAME, AND THIS IS ADDING A BUNCH FOR ONE, SO NO!!!
            /*layerDrawings.Add(drawing);*/
            //GET THE STROKE DATA
            foreach (Stroke stroke in strokesCopy)
            {
              layerStrokes.Add(stroke);
            //Console.WriteLine(stroke.BoundingBox);
            newBox.Expand(stroke.BoundingBox);
            Console.WriteLine("newBox: "+ newBox);//CHECK OUT OUTPUT MORE AND SEE WHAT'S WRONG!!!!
            //Console.WriteLine(flattenedLayer.Drawings[0].BoundingBox);
            }

        }

        
        flattenedLayer.Drawings[0].Data.Strokes = layerStrokes;
        flattenedLayer.Drawings[0].BoundingBox = newBox;//OKAY BUT THIS IS MAKING ALL OF THEM THE SAME!!! WHY WOULD THAT BE???? PLAY AROUND WITH THIS MORE!!!
        ((LayerPaint)flattenedLayer).Frames = new List<int> { 0}; //WOW NOW IT ACTUALLY SHOWS UP!!!
        //GAH just realized they SHOULD all have the same bounding boxes, because they all have the same stroke data!! So...  dunno what issue could be then
        //*****************FRAMES-- CURRENTLY EMPTY, I HTINK IT SHOULD BE 0.0 SEE OTHER FILE!!!!
        //Console.WriteLine(flattenedLayer.Drawings[0].Data.Strokes[0].BoundingBox);
        //flattenedLayer.Drawings[0].UpdateBoundingBox(false);
        Console.WriteLine(flattenedLayer.Drawings[0].BoundingBox);
        flattenedLayer.Visible = false; //otherwise might be too many visible at once, performance issues
        newSequence.InsertLayerAt(flattenedLayer, "");
      }
      //if it's already a single paint layer, want to make sure that is added to the Quill file
      else
      {
        //Layer newLayer = child.DeepCopy(child.Name);//testing using a clone, bc for some reason this also empty of strokes??
        
        //layers.Add(child);
        newSequence.InsertLayerAt(child, "");//CHANGE BACK TO NEW LATER??
      }
    }
  }
  
}


FlattenLayers(readSequence.RootLayer);
/*foreach (Layer lay in layers)
{
  readSequence.InsertLayerAt(lay, ""); //OKAY SOMETHING GOING ON!!! BC EVEN WITH NOTHING CHANGING IT'S DELETING ALL STROKE DATA!!!
}*/
QuillSequenceWriter.Write(newSequence, writePath);
