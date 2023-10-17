using SharpQuill;
using System.Reflection.Emit;

//read in the 2 layers and find out how their main storage is different-- how many vertices, position of vertices. Can we maybe draw a very simple version?? or use graphing software??

//could also try building a layer from scratch, based on main stuff?
//what happens if I delete vertices?

string readPath = "C:\\Users\\amkas\\OneDrive\\Desktop\\QuillCodeStuff\\Pixel_1m\\Pixel_1m";
var sequence = QuillSequenceReader.Read(readPath);
var writepath = readPath + "_Edited";

//below so I know what the layers are called, will hard code
foreach (Layer child in ((LayerGroup)sequence.RootLayer).Children)
{
  Console.WriteLine(child.Name);
}
LayerPaint square = (LayerPaint)sequence.RootLayer.FindChild("PerfectSquare1");
//LayerPaint six = (LayerPaint)sequence.RootLayer.FindChild("6-tri");
//LayerPaint ten = (LayerPaint)sequence.RootLayer.FindChild("Ten-tri");

//HEY HEY HEY-- i'm so tired but yeah SEE IF YOU CAN SUPERIMPOSE
//maybe not using this code
//Just assuming 1 drawing for this test (so, Drawings[0])
//should also assume one stroke but I didn't
/*var sixStrokes = six.Drawings[0].Data.Strokes.Count;
var tenStrokes = ten.Drawings[0].Data.Strokes.Count;*/
var sqStrokes = square.Drawings[0].Data.Strokes.Count;
Console.WriteLine("line 29: " + sqStrokes);
Stroke sqStroke = square.Drawings[0].Data.Strokes[0].Clone();

/*Stroke tenStroke = ten.Drawings[0].Data.Strokes[0].Clone();
Vertex v1 = ten.Drawings[0].Data.Strokes[0].Vertices[3];//this is a shallow copy!! v shallow
Vertex v2 = ten.Drawings[0].Data.Strokes[0].Vertices[4];
tenStroke.Vertices.Clear();
tenStroke.Vertices.Add(v1);
tenStroke.Vertices.Add(v2);
tenStroke.UpdateBoundingBox();//eh?*/

//start fresh with a blank layer
LayerPaint perfectPixel = new LayerPaint("perfectPixel", true);
//instantiate list of Vertex here
List<Vertex> newVertices = new List<Vertex>();
Vertex firstVert = sqStroke.Vertices[0];
//get info from first vertex of square
SharpQuill.Vector3 p1 = new SharpQuill.Vector3(0, 0, -0.5f);
SharpQuill.Vector3 p2 = new SharpQuill.Vector3(0, 0, 0.5f);
Vertex v_01 = new Vertex(p1, firstVert.Normal, firstVert.Tangent, firstVert.Color, firstVert.Opacity, firstVert.Width);
Vertex v_02 = new Vertex(p2, firstVert.Normal, firstVert.Tangent, firstVert.Color, firstVert.Opacity, firstVert.Width);
newVertices.Add(v_02);
newVertices.Add(v_01);
Stroke newStroke = sqStroke.NewPosStroke(newVertices);
newStroke.UpdateBoundingBox();
perfectPixel.Drawings[0].Data.Strokes.Add(newStroke);
perfectPixel.Drawings[0].UpdateBoundingBox(false);
//then add to sequence
sequence.InsertLayerAt(perfectPixel, "");


//OutputVertices(square, sqStrokes);



/*var vert = square.Drawings[0].Data.Strokes[0].Vertices[0];
Vector3 v0Pos = new Vector3(vert.Position.X, vert.Position.Y, -vert.Width);
Vector3 v1Pos = new Vector3(vert.Position.X, vert.Position.Y, vert.Width);


Vertex v0 = new Vertex(v0Pos, vert.Normal, vert.Tangent, vert.Color, vert.Opacity, vert.Width);
Vertex v01 = new Vertex(v0Pos, vert.Normal, vert.Tangent, vert.Color, vert.Opacity, vert.Width);
Vertex v1 = new Vertex(v1Pos, vert.Normal, vert.Tangent, vert.Color, vert.Opacity, vert.Width);
Vertex v11 = new Vertex(v1Pos, vert.Normal, vert.Tangent, vert.Color, vert.Opacity, vert.Width);
List<Vertex> newVerts = new List<Vertex>() { v0, v01, v1, v11 };
square.Drawings[0].Data.Strokes[0].Vertices.Clear();
square.Drawings[0].Data.Strokes[0].Vertices = newVerts;
square.Drawings[0].Data.Strokes[0].UpdateBoundingBox(); 
square.Drawings[0].UpdateBoundingBox(false);//actually it should be false, because strokes already updated
*/

//square.Drawings[0].Data.Strokes[0].Vertices[0] = 
/*OutputVertices(six, sixStrokes);
OutputVertices(ten, tenStrokes);*/

//LayerPaint testNewLayer = new LayerPaint("optimized_maybe", true);

/*testNewLayer.Drawings[0].Data.Strokes.Add(tenStroke);
testNewLayer.Drawings[0].UpdateBoundingBox(true);//not sure if necessary*/

//sequence.InsertLayerAt(testNewLayer, "");

QuillSequenceWriter.Write(sequence, writepath);


void OutputVertices(LayerPaint layer, int numStrokes)
{
  Console.WriteLine(layer.Name + " info:");
  for (int i= 0; i<numStrokes; i++)
  {
    Console.WriteLine("Stroke " + i + ": ");
    var currStrokeVCount = layer.Drawings[0].Data.Strokes[i].Vertices.Count;
    giveVertInfo(layer, currStrokeVCount, i);
    layer.Drawings[0].Data.Strokes[i].UpdateBoundingBox();
  };
  layer.Drawings[0].UpdateBoundingBox(true);
  Console.WriteLine();
}


void giveVertInfo(LayerPaint layer, int vertCount, int curStroke)
{

  for (int i = 0; i < vertCount; i++)
  {
    Vector3 position;
    //hardcoding this for now cuz i dumb
    if (i < 2)
    {
      position = new Vector3(0, 0, -0.5f);
    }
    else
    {
      position = new Vector3(0, 0, 0.5f);
    }
    
    var vert = layer.Drawings[0].Data.Strokes[curStroke].Vertices[i];
    Vertex newVert = new Vertex(position, vert.Normal, vert.Tangent, vert.Color, vert.Opacity, vert.Width);
    layer.Drawings[0].Data.Strokes[curStroke].Vertices[i] = newVert;
    Console.WriteLine("Vertex " + i + ": ");
    //Console.WriteLine("Normal: " + vert.Normal.X + ", " + vert.Normal.Y + ", " + vert.Normal.Z);
    Console.WriteLine(vert.ToString());
  }

}





/*var tenVs = six.Drawings[0].Data.Strokes[0].Vertices;
Console.WriteLine("Printing ten vertex data:");
for (int i = 0; i < tenVs.Count; i++)
{
  var vert = six.Drawings[0].Data.Strokes[0].Vertices[i];
  Console.WriteLine("Vertex " + i + ": ");
  Console.WriteLine("Normal: " + vert.Normal.X + ", " + vert.Normal.Y + ", " + vert.Normal.Z);
  Console.WriteLine("Position: " + vert.Position.X + ", " + vert.Position.Y + ", " + vert.Position.Z);
}
*/


