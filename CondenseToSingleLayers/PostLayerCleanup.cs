using SharpQuill;
using System.IO;

var readPath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder_blendshapes";
//some sample file paths: "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\scriptPractice_FolderCopies\\Face-test_Onefolder_blendshapes"
//whatever it is, needs to be the reference to the Quill folder that was modified by original script (test it first to check)
var suffix = "_layersTidied";
//default, change to whatever you want
var writePath = readPath + suffix;

//I really want to do like, sequence.RootLayer.children, you know??
// Create the standard default scene but without any paint layer.


void FlattenLayers(Layer layer)
{
  var newSequence = Sequence.CreateDefault();
  if (layer is LayerGroup) //will be true for Root
  {
    foreach (Layer child in ((LayerGroup)layer).Children)
    {
      if (child is LayerGroup)
      {
        //make an empty paint layer with the name of the group
        var path = "/" + child.Name; 
        LayerPaint flattenedLayer = new LayerPaint(child.Name);
        var allStrokes = new List<Stroke>();
        var mergedDrawing = new Drawing();

        //iterate through all the children of this child--
        //Use: Drawings.Add(new Drawing()); see LayerPaint.cs
        foreach (Layer grandchild in ((LayerGroup)child).Children) 
        {
          //going to assume these are now all just plain paint layers
          var listOfDrawings = ((LayerPaint)grandchild).Drawings;
          //Console.Write(listOfDrawings);
          var x = 0;
          foreach (Drawing drawing in listOfDrawings) {
            Console.WriteLine(drawing.BoundingBox);
            mergedDrawing.BoundingBox.Expand(drawing.BoundingBox);//WHY IS THIS NOT WORKING?????????????????????????
            //Console.WriteLine(mergedDrawing.BoundingBox);

            foreach (Stroke stroke in drawing.Data.Strokes)
            {
             
              allStrokes.Add(stroke);// can set or get strokes, but maybe can't add directly to the data so doing later?
              //Console.WriteLine(allStrokes[x].BoundingBox);
              x++;
            }
        
          }

        }
        //trying adding a new drawing with all the specified strokes!
        
        mergedDrawing.Data.Strokes = allStrokes;
        //Console.WriteLine(mergedDrawing.Data.Strokes.Count); //so it has all 26 strokes captured, so it's accurate stroke data I think! And stroke bounding boxes were being added. So... what's going on??
        //mergedDrawing.UpdateBoundingBox(true);
        //Console.WriteLine(mergedDrawing.BoundingBox);
        flattenedLayer.Drawings = new List<Drawing> { mergedDrawing };
        flattenedLayer.Visible = false; //otherwise might be too many visible at once, performance issues
        newSequence.InsertLayerAt(flattenedLayer, "");
      }
      //if it's already a single paint layer, want to make sure that is added to the Quill file
      else
      {
        newSequence.InsertLayerAt(child, "");
      }
    }
  }
  QuillSequenceWriter.Write(newSequence, writePath);
}

var readSequence = QuillSequenceReader.Read(readPath);
FlattenLayers(readSequence.RootLayer);
