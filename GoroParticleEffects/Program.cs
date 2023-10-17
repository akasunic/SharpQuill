using SharpQuill;
using System;
using System.Numerics;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Drawing;
using System.Text;

//Steady particles test
//take a simple drawing from a paint layer-- let's do hearts, to practice for more than 1 stroke (though default would be circle), randomly duplicate within a range, ideally keeping within 1 layer
//suggested size-- maybe put tool tips for everything, have a readme sheet-- TEST THE REOPEN PROCESS
// look back at video: how many within original thing before duplicated, and then within
//and what is the range? Put some markers in quill in to get a sense-- maybe using the grid as starting point? Goro has 54 points, and over almost all of the grid
//then, take that whole drawing and duplicate it and move it along the X axis (I'm pretty sure)-- look at bounding box for starting y? can change on drawing level or vertex level?
//dude is there a quest simulator???-- or even just little shortcuts/tricks to easily start things up without actually using the headset
//then put this layer in a group, put linear transform at certain parts (when you do the math, keep fps as a var so can be changed-- remember time stored in milliseconds)
//and put that group into a group, make it a sequence, loop it at same point as key transform

//Not necessary for this, but useful: do a simple baking test
//let's say, just a circle moving along a keyframe, linear interpolation
//oh, would need algorithms for linear, ease in, ease out, etc. but let's just start with linear

var numObjs = 100;//hardcoding for now-- see Goro numbers, etc-- I think I had written 51
var numDups = 4; //hardcoding for now-- how many times you want to move it over to the right (X axis) to offset
var sequence = QuillSequenceReader.Read("C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\Grid-test");
var writePath = "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\randomizedParticles";
var heartLayer = (LayerPaint)sequence.RootLayer.FindChild("Heart");
LayerPaint heartCopy = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(heartLayer));
LayerPaint emptyLayer = new LayerPaint("emptyLayer", true);
/*for (int h=0; h<heartCopy.Drawings.Count-1; h++)// subtract 1 because you start with an empty drawing
{
  //add a clone of the first drawing of the empty layer, so you have an equal num of empty drawings
  heartCopy.Drawings.Add(heartCopy.Drawings[0].Clone());
}*/

//make a deep copy, otherwise original will be altered
heartCopy.Name = "heartCopy";
Console.WriteLine("just testing");

var quillGridDict = new Dictionary<string, int>
{
  {"xMin", -10},
  {"xMax", 10},
  {"yMin", 0},
  {"yMax", 20},
  {"zMin", -10},
  {"zMax", 10}
};
//hardcodingt he factors for now-- can set to different later 
var xFact = 1;
var yFact = 1;
var zFact = 1;

//traverse the vertices of the drawing, taking the original and adding

//return instead of void here
//going to assume the first frame if it's frame by frame animation! (so, Drawings[0])-- OHHH actually I should just do for all frames. Bc then more reusable
//want to always work with the original layer for each stroke, and then
//NOTE: might want to later ensure that original object is at roughly center (0,0,0)-- just make sure it's first vertex is. Have a little ftn to center in the original layer, perhaps
//might want to rename this... it's copy and reposition object currently bc I think that's what it's doing but I gotta double check cuz I already forget
//NOTE: should have a test if it's a frame by frame or not! should have just 1 drawing. OR after you do the deserialization, delete drawings after Drawings[0}. Up to you. Omit for now
void CopyReposObj(LayerPaint origLayer, LayerPaint newLayer)
{
  //want the same randomization across all vertices of all strokes, so apply here, at the drawing level
  //note that these values may be exclusive, need to double check documentation
  //CenterObject(origLayer); //maybe make a ftn for this and add in later
  //hm, maybe need a new seed each time? otherwise it's looking kinda strange. Let me see. Before I had this outside of the function
  var randXseed = new Random();
  var randYseed = new Random();
  var randZseed = new Random();

  //want the angle at the top level
  double angleX = GenAngleInRadians();
  double angleY = GenAngleInRadians();
  double angleZ = GenAngleInRadians();

  var randXOffset = xFact * randXseed.Next(quillGridDict["xMin"], quillGridDict["xMax"]);
  var randYOffset = yFact * randYseed.Next(quillGridDict["yMin"], quillGridDict["yMax"]);
  var randZOffset = zFact * randZseed.Next(quillGridDict["zMin"], quillGridDict["zMax"]);
   
  for (int i=0; i< origLayer.Drawings[0].Data.Strokes.Count; i++)
    {
      var stroke = origLayer.Drawings[0].Data.Strokes[i];
      //instantiate list of Vertex here
      List<Vertex> newVertices = new List<Vertex>();

      //also instatiate the list of the lists of duplicated vertices
      //will be adding to these each time you add a vertex to newVertices
      List<List<Vertex>> dupVertices = new List<List<Vertex>>();
      for (int dups = 0; dups<numDups; dups++)
      {
        dupVertices.Add(new List<Vertex>());
      }
  
      for (int v = 0; v<stroke.Vertices.Count; v++)
      {
        var vertex = stroke.Vertices[v];
        float X = vertex.Position.X;
        float Y = vertex.Position.Y;
        float Z = vertex.Position.Z;

        //now apply randomized rotation
        //Note: using ref so that the orinal values get changed
        RotateVertex(angleX, "X", ref X, ref Y, ref Z);
        RotateVertex(angleY, "Y", ref X, ref Y, ref Z);
        RotateVertex(angleZ, "Z", ref X, ref Y, ref Z);

        //apply offset after have rotated?
        X += randXOffset;
        Y += randYOffset;
        Z += randZOffset;

        //agh, maybe this won't work, need to understand SharpQuill.Vector3 vs the built in Vector3... why is there a new Vector3 in SharpQuill??
        SharpQuill.Vector3 newPos = new SharpQuill.Vector3(X, Y, Z);
      
        Vertex newRandV = new Vertex(newPos, vertex.Normal, vertex.Tangent, vertex.Color, vertex.Opacity, vertex.Width);
        newVertices.Add(newRandV);

        // now you want to take this stroke, and clone offset and for numDups, offset it gridX * Xfactor (but at vertex level)
        //also re-do this for original strokes, too!
        for (int dups = 0; dups < numDups; dups++)
        {
          var fact = dups + 1;
          SharpQuill.Vector3 transXPos = new SharpQuill.Vector3(newPos.X + fact*xFact*(quillGridDict["xMax"] - quillGridDict["xMin"]), newPos.Y, newPos.Z);
          Vertex newDupVert = new Vertex(transXPos, vertex.Normal, vertex.Tangent, vertex.Color, vertex.Opacity, vertex.Width);
          dupVertices[dups].Add(newDupVert);
        }
        //then add this new vertex to the copied layer's vertices list
        //OHHH you want a new stroke, though... okay


      }
      //add new stroke to drawing here, add in vertices, reset bounding boxes!
      Stroke newStroke = stroke.NewPosStroke(newVertices);
      newStroke.UpdateBoundingBox();
      newLayer.Drawings[0].Data.Strokes.Add(newStroke);

      //for the dups
      for (int d = 0; d<numDups; d++)
      {
        Stroke dupStroke = stroke.NewPosStroke(dupVertices[d]);
        dupStroke.UpdateBoundingBox();
        newLayer.Drawings[0].Data.Strokes.Add(dupStroke);
      }

    
     
    }
  //update drawing bbox here?? double check where it's stored
    newLayer.Drawings[0].UpdateBoundingBox(false);//setting to false bc already updated stroke bbox above-- can play around with this if not working
  }


//for however many times chosen, copy


//Okay, let's say this is good enough for now-- now let's do STEP 2, which is to move all the strokes from this layer and copy by
//size of grid*Xfactor
//certain num of times-- numDups


for (int i = 0; i < numObjs; i++)
{
   //hard coding heartLayer for now! Redo later!
  CopyReposObj(heartLayer, emptyLayer);
}


//OKAY NOW THIS IS THE ANIMATION PART!!!

//put the new layer in a folder
LayerGroup layerParent = new LayerGroup("layerParent", false);
LayerGroup seqGroup = new LayerGroup("seqGroup", true);//set to true to mark as a sequence

Transform transform1 = new Transform(new SharpQuill.Quaternion(0, 0, 0, 1), 1.0f, "N", new SharpQuill.Vector3(0, 0, 0));

Transform transform2 = new Transform(new SharpQuill.Quaternion(0, 0, 0, 1), 1.0f, "N", new SharpQuill.Vector3(xFact * (quillGridDict["xMax"] - quillGridDict["xMin"]), 0, 0));
//add 2 key transforms to layerParent, setting to 1 second for now [HARD CODE NOW< MAKE AN OPTION LATER]
Keyframe<Transform> initialKey = new Keyframe<Transform>(0, transform1, Interpolation.Linear);
Keyframe<Transform> endKey = new Keyframe<Transform>(12600, transform2, Interpolation.Linear);//using milliseconds I think! ACTUALLY 12600 is 1 second i have no idea why???
//want to move it by gridSize*xFactor for x; y and z remain the same
layerParent.Animation.Keys.Transform.Add(initialKey); 
layerParent.Animation.Keys.Transform.Add(endKey);

//to loop sequence at a specific point, i think it's just the duration?
seqGroup.Animation.Duration = 12600; //again, won't hard code this for this version
Console.WriteLine(layerParent.Animation.Keys.Transform );

//can we set animation to seqGroup and add paint layer after??
sequence.InsertLayerAt(seqGroup, "");
sequence.InsertLayerAt(layerParent, "/seqGroup");
sequence.InsertLayerAt(emptyLayer, "/seqGroup/layerParent");
Console.WriteLine("finding group: "+ sequence.RootLayer.FindChild("layerParent"));
QuillSequenceWriter.Write(sequence, writePath);




//for now, will assume it's a single drawing (not animated fXf)
//so want to take that first drawing, and randomize the location within a range/bounding box
//so need to see where/how this info is stored!
//note: to combine two drawings  they in separate layers or separate keyframes), I THINK basically will just add strokes from other drawing
//and should be able to update bounding box of drawing after strokes added by doing Drawing.UpdateBoundBox(false);
//test it out..
//heartCopy.Drawings[0]
//so one option would be to mess with transform values, but really, we want those applied at the stroke/vertex level
//so have an X, y, Z range, and modify the vertices-- hm, could even start with that first one. then honestly, never have to worry about the beggingin positon
//yeah okay


//PrintGridTestInfo();
//TESTS: what are the dimensions of the grid in Quill?? go from there, then-- make cube, label each-- also put points and label those, and then print out
//Okay so gonna draw some things in Quill and then print it out, okay? Specifically to understand dimensions of the grid. Then will mark in
void PrintGridTestInfo()
{

  LayerGroup cube = (LayerGroup)sequence.RootLayer.FindChild("Cube");
  for (int l = 0; l < cube.Children.Count; l++)
  {
    Console.WriteLine(cube.Children[l].Name);
    var currLayer = cube.Children[l];
    //Console.WriteLine(currLayer.Type);
    if (currLayer.Type.ToString() == "Group")
    {
      LayerGroup groupLayer = (LayerGroup)currLayer;
      foreach (var layer in groupLayer.Children)
      {

        if (layer.Type.ToString() == "Paint")
        {
          LayerPaint paintLayer = (LayerPaint)layer;
          PrintBBoxData(paintLayer);
        }
      }
    }
    else if (currLayer.Type.ToString() == "Paint")
    {
      LayerPaint paintLayer = (LayerPaint)currLayer;
      PrintBBoxData(paintLayer);
    }

  }

}
//Below is WRONG
//A realization: so to move a stroke, you do have to move all the vertices (which may be 45, or what have you).
//but we can use stroke BBox as a starting point, potentially-- basically, going to translate and rotate it all around
//but actually, rotation is an issue-- when you rotate a selected stroke-- Ah. I see. For a vertex, moving it actually also rotates the stroke. okay
//ok so now need to see that vertices and strokes are using XYZ the same, I'm sure they are
//so want to "reset" a vertex to the middle, right? or to the closest equiv to 000? by figuring out offset to get just ONE vertx to 000
//and then use that as the basis for moving it all about the grid, sound good? so you just pick a point, and go with it. let's see!! I mean
//I'm not ready yet but let's see shortly...
//ok so center of grid is 0,0,0, then X goes -10 to 10, y (if keeping grid as floor) 0-20, and Z -10 to 10


//so plan to randomize the heart: take the drawing layer, and using range above, -- blah blah blah add to it and shit gah I need to explore more! 
//
void PrintBBoxData(LayerPaint paintLayer)
{
  Console.WriteLine(paintLayer.Name);
  for (int d = 0; d < paintLayer.Drawings.Count; d++)
  {
    for (int i = 0; i < paintLayer.Drawings[d].Data.Strokes.Count; i++)
    {
      //ok, you want bounding box of the stroke!
      Console.WriteLine("stroke bounding box: " + paintLayer.Drawings[d].Data.Strokes[i].BoundingBox.ToString());
      //Console.WriteLine("vertex count per stroke: " + paintLayer.Drawings[d].Data.Strokes[i].Vertices.Count);
   /*   for (int v = 0; v < paintLayer.Drawings[d].Data.Strokes[i].Vertices.Count; v++)
      {
        Console.WriteLine("Vertex info: ");
        Console.WriteLine(paintLayer.Drawings[d].Data.Strokes[i].Vertices[v].Position.X);
        Console.WriteLine(paintLayer.Drawings[d].Data.Strokes[i].Vertices[v].Position.Y);
        Console.WriteLine(paintLayer.Drawings[d].Data.Strokes[i].Vertices[v].Position.Z);
      }*/
      Console.WriteLine();
    }
  }
}



//output the angleInRandians-- should do this at the drawing layer, though!!
//will do this 3 times at the drawing level when making a new copy of object, store 
double GenAngleInRadians()
{
  // Generate a random angle in degrees within a desired range
  Random rotRandom = new Random();
  double minAngle = -Math.PI;  // -180 degrees in radians
  double maxAngle = Math.PI;   // 180 degrees in radians
  double randomAngle = rotRandom.NextDouble() * (maxAngle - minAngle) + minAngle;

  // Convert the random angle to radians
  double angleInRadians = randomAngle;

  return angleInRadians;


}

//going to randomly rotate all vertices in a drawing along all 3 axes
//place so X Y Z are at same level, so you can mod directly
//use ref so original values change-- may need to look up more on this to understand later...
//I also like, don't understand rotation in gen. will look into later
void RotateVertex(double angleInRadians, string axis, ref float X, ref float Y, ref float Z)
{
  double sinTheta = Math.Sin(angleInRadians);
  double cosTheta = Math.Cos(angleInRadians);
  double newX;
  double newY;
  double newZ;
  switch (axis)
  {
    case "X":
      newY =Y*cosTheta - Z * sinTheta;
      newZ = Y * sinTheta + Z * cosTheta;
      newX = X;
      X = (float)newX;
      Y = (float)newY;
      Z = (float)newZ;
      break;

    case "Y":
      newY = Y;
      newX = X * cosTheta + Z * sinTheta;
      newZ = Z * cosTheta - X * sinTheta;
      X = (float)newX;
      Y = (float)newY;
      Z = (float)newZ;
      break;

    case "Z":
      newZ = Z;
      newX = X * cosTheta - Y * sinTheta;
      newY = X * sinTheta + Y * cosTheta;
      X = (float)newX;
      Y = (float)newY;
      Z = (float)newZ;
      break;
  }

}




