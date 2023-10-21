using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpQuill
{
  
  public class SteadyParticles
  { 
    private int numObjs; //how many times to duplicate the drawing/object from the base layer in one set
    private int numDups; //how many times over to duplicate the area of random particles
    private Sequence sequence; //the sequence where you'll be adding the new vfx
    private LayerPaint startLayer; //typically, a static paint layer with one small object

    private int secondsConversion = 12600;//why this is true in Quill I have no idea, but this is equiv of 1 sec in Quill time in Quill.json
    //the quillGridDict represents a cubic area based off length of the grid, that sits atop the grid. It is used as the basis for resizing the desired output area
    private Dictionary<string, int> quillGridDict = new Dictionary<string, int>
    {
      {"xMin", -10},
      {"xMax", 10},
      {"yMin", 0},
      {"yMax", 20},
      {"zMin", -10},
      {"zMax", 10}
    };
    private float xFact; //multiplier for size of output area x length in relation to cube above. Same for the next two 
    private float yFact;
    private float zFact;
    private float loopTime;
    private bool rotate;

    public SteadyParticles(int numObjs, int numDups, Sequence sequence, LayerPaint startLayer, float xFact, float yFact, float zFact, float loopTime, bool rotate)
    {
      this.numObjs = numObjs;
      this.numDups = numDups;
      this.sequence = sequence;
      this.startLayer = startLayer;
      this.xFact = xFact;
      this.yFact = yFact;
      this.zFact = zFact;
      this.loopTime = loopTime*secondsConversion;//converting from seconds to Quill units
      this.rotate = rotate;
    }

    public void GenerateSteadyParticles()
    {
      LayerPaint startCopy = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(this.startLayer));
      startCopy.Name = "looping images";// playing around with how to portray
      LayerPaint targetLayer = new LayerPaint("randomized particles", true); //this would be to start with an empty layer
      //LayerPaint targetLayer = startCopy;//this will keep the original drawing in there-- should help for moving backgrounds
      if (numObjs < 1)
      {
        //not going to generate a random array
        //this can be useful for hacky purposes (image loops)
        //or for those who want to do this in a 2-step process (eg, to manually edit the particle array first)
        targetLayer = startCopy;
        OffsetOnly(targetLayer);
      }
      else
      {
        for (int i = 0; i < numObjs; i++)
        {
          //first generate the random array of particles
          CopyReposObj(targetLayer);
        }


      }

      //Create folders for animation
      LayerGroup layerParent = new LayerGroup("layerParent", false);
      LayerGroup seqGroup = new LayerGroup("seqGroup", true);//set to true to mark as a sequence

      Transform transform1 = new Transform(new SharpQuill.Quaternion(0, 0, 0, 1), 1.0f, "N", new SharpQuill.Vector3(0, 0, 0));

      Transform transform2 = new Transform(new SharpQuill.Quaternion(0, 0, 0, 1), 1.0f, "N", new SharpQuill.Vector3(xFact * (quillGridDict["xMax"] - quillGridDict["xMin"]), 0, 0));
      //add 2 key transforms to layerParent, setting to 1 second for now [HARD CODE NOW< MAKE AN OPTION LATER]
      Keyframe<Transform> initialKey = new Keyframe<Transform>(0, transform1, Interpolation.Linear);
      Keyframe<Transform> endKey = new Keyframe<Transform>((int)loopTime, transform2, Interpolation.Linear);//not using milliseconds as original SharpQuill suggestion! ACTUALLY 12600 is 1 second i have no idea why???

      //want to move it by gridSize*xFactor for x; y and z remain the same
      layerParent.Animation.Keys.Transform.Add(initialKey);
      layerParent.Animation.Keys.Transform.Add(endKey);

      //to loop sequence at a specific point, it's just the duration
      seqGroup.Animation.Duration = (int)loopTime;

      if(numDups > 0)
      {
        sequence.InsertLayerAt(seqGroup, "");
        sequence.InsertLayerAt(layerParent, "/seqGroup");
        sequence.InsertLayerAt(targetLayer, "/seqGroup/layerParent");
      }
      else
      {
        sequence.InsertLayerAt(targetLayer, "");
      }

    }

    //This is a workaround bc I encountered issues with the bounding boxes! Used for offset only, in case the bounding boxes are not accurate
    //Basically, just finds xBounds of a drawing (using vertices), so that this value can be used to copy and displace
    public static float FindXBounds(LayerPaint layer)
    {
      float Xmin = 0;
      float Xmax = 0;
      for (int s= 0; s< layer.Drawings[0].Data.Strokes.Count; s++)
      {
        Stroke stroke = layer.Drawings[0].Data.Strokes[s];
        for (int v= 0; v<stroke.Vertices.Count; v++)
        {
          Vertex vert = stroke.Vertices[v];
          if (Xmin > vert.Position.X)
          {
            Xmin = vert.Position.X;
          }
          else if (Xmax < vert.Position.X)
          {
            Xmax = vert.Position.X;
          }
        }
      }
      return Xmax - Xmin;
    }

    //This method used if not duplicating/randomizing, but only doing the displace/animating part
    //might be useful if doing a moving background (skipped the particle array part)
    //or if 
    public void OffsetOnly(LayerPaint newLayer)
    {

      //I know I should just refactor so this is included in other function, but... this is so much easier to do right now
      float xBounds = FindXBounds(startLayer);
      float bboxOffset;
      

      //for number of duplicates, traverse all vertices in the paint layer, and duplicate with an X offset
      for (int dups = 0; dups < numDups; dups++)
      {
        
        bboxOffset = xBounds * (dups + 1);
        //for each stroke in drawing
        for (int s=0; s<startLayer.Drawings[0].Data.Strokes.Count; s++)
        {
          List<Vertex> vertices = new List<Vertex>();
          Stroke stroke = startLayer.Drawings[0].Data.Strokes[s];
          //for each vertex in stroke
          for (int v=0; v < stroke.Vertices.Count; v++)
          {
            Vertex vertex = stroke.Vertices[v];
            
            SharpQuill.Vector3 transXPos = new SharpQuill.Vector3(vertex.Position.X + bboxOffset, vertex.Position.Y, vertex.Position.Z);
            Vertex newDupVert = new Vertex(transXPos, vertex.Normal, vertex.Tangent, vertex.Color, vertex.Opacity, vertex.Width);
            vertices.Add(newDupVert);
          }

          Stroke dupStroke = stroke.NewPosStroke(vertices);
          dupStroke.UpdateBoundingBox();
          newLayer.Drawings[0].Data.Strokes.Add(dupStroke);
          
        }
        
      }
      //this is not working as expected-- the bounding box is set to {0,0,0,0,0,0}! will edit later if I figure out issue. but using workarounds for now
      newLayer.Drawings[0].UpdateBoundingBox(false);
    }



    //This is for copying and repositioning the original object
    //It automates everything here, including the keyframe animation
    //numDups can be 0, in which case the animation part isn't created (eg, just creating a particle array, static)
    public void CopyReposObj(LayerPaint newLayer)
    {
      
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

      for (int i = 0; i < startLayer.Drawings[0].Data.Strokes.Count; i++)
      {
        var stroke = startLayer.Drawings[0].Data.Strokes[i];
        //instantiate list of Vertex here
        List<Vertex> newVertices = new List<Vertex>();

        //also instatiate the list of the lists of duplicated vertices
        //will be adding to these each time you add a vertex to newVertices
        List<List<Vertex>> dupVertices = new List<List<Vertex>>();
        for (int dups = 0; dups < numDups; dups++)
        {
          dupVertices.Add(new List<Vertex>());
        }

        for (int v = 0; v < stroke.Vertices.Count; v++)
        {
          var vertex = stroke.Vertices[v];
          float X = vertex.Position.X;
          float Y = vertex.Position.Y;
          float Z = vertex.Position.Z;

          if (rotate)//if chose to rotate via checkbox, then randomly rotate
          {
            //now apply randomized rotation
            //Note: using ref so that the orinal values get changed
            RotateVertex(angleX, "X", ref X, ref Y, ref Z);
            RotateVertex(angleY, "Y", ref X, ref Y, ref Z);
            RotateVertex(angleZ, "Z", ref X, ref Y, ref Z);
          }
          
          //apply offset after have rotated
          X += randXOffset;
          Y += randYOffset;
          Z += randZOffset;

          SharpQuill.Vector3 newPos = new SharpQuill.Vector3(X, Y, Z);

          Vertex newRandV = new Vertex(newPos, vertex.Normal, vertex.Tangent, vertex.Color, vertex.Opacity, vertex.Width);
          newVertices.Add(newRandV);

          // now you want to take this stroke, and clone offset and for numDups, offset it gridX * Xfactor (but at vertex level)
         
          for (int dups = 0; dups < numDups; dups++)
          {
            var fact = dups + 1;
            SharpQuill.Vector3 transXPos = new SharpQuill.Vector3(newPos.X + fact * xFact * (quillGridDict["xMax"] - quillGridDict["xMin"]), newPos.Y, newPos.Z);
            Vertex newDupVert = new Vertex(transXPos, vertex.Normal, vertex.Tangent, vertex.Color, vertex.Opacity, vertex.Width);
            dupVertices[dups].Add(newDupVert);
          }
        }
        //add new stroke to drawing here, add in vertices, reset bounding boxes!
        Stroke newStroke = stroke.NewPosStroke(newVertices);
        //note: I believe updating Bboxes may be working at stroke level. I need to confirm, though.
        newStroke.UpdateBoundingBox();
        newLayer.Drawings[0].Data.Strokes.Add(newStroke);
  
        //for the dups
        for (int d = 0; d < numDups; d++)
        {
          Stroke dupStroke = stroke.NewPosStroke(dupVertices[d]);
          dupStroke.UpdateBoundingBox();
          newLayer.Drawings[0].Data.Strokes.Add(dupStroke);
          
        }



      }
      newLayer.Drawings[0].UpdateBoundingBox(false);//agh, still doesn't work, but keeping here in case I find a solution later.

    }

    //chatgpt helped me because i didn't know how to rotate...
    public static double GenAngleInRadians()
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
    //use ref so original values change
    public static void RotateVertex(double angleInRadians, string axis, ref float X, ref float Y, ref float Z)
    {
      double sinTheta = Math.Sin(angleInRadians);
      double cosTheta = Math.Cos(angleInRadians);
      double newX;
      double newY;
      double newZ;
      switch (axis)
      {
        case "X":
          newY = Y * cosTheta - Z * sinTheta;
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

  }

}
