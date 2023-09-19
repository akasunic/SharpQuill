using SharpQuill;
using System;
using System.Numerics;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;


Console.WriteLine("Testing: new project");
/*
 Going to start with some psuedocode and steps that need to be take for this

1. Find example of a particle effect. Can see Quill projects eg Goro's work, or generic things about projects.

2. Choose stroke layer you want to work on

3. Have parameters for particle effect...

rate over time: how often new particles are spawned
rate over distance: how far they need to move before a new particle is introduced

 */

//QUESTION: WHY DIDN'T MY STATIC VOID MAIN FTN WORK???

var sequence = QuillSequenceReader.Read("C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\part-heart-test");
//let's see if we can add a new layer to the same file and reopen
//SCRATCH THAT! Let's just merge two files, then-- so like you have an existing quill file, and then you add certain particle effects to it from the particle effects library
//and that's now a new file
//



var newBlankLayer = new LayerPaint("testLayer3", true);

//okay now let's get that layer and see if we can change color
//then change scale
//then change color annd shape as an animation
//then change timing of that existing animation

Console.WriteLine(sequence.RootLayer.Children[1].Name);

var heartLayer = (LayerPaint)sequence.RootLayer.Children[1]; //hard coding for now
//var blueHeart = (LayerPaint)heartLayer.DeepCopy("blueHeart");
//var bigHeart = (LayerPaint)heartLayer.DeepCopy("bigHeart");

//YOU NEED THIS TO DO A DEEP COPY< BELOW-- I WAS MAKING A SHALLOW COPY BEFORE
LayerPaint blueHeart = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(heartLayer));
blueHeart.Name = "blueHeart";
LayerPaint bigHeart = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(heartLayer));
bigHeart.Name = "bigHeart";

//need to divide by 255 bc stored in this format in SharpQuill-- v important to make float type explicit, otherwise does int division!
var blue = new Color(36/255f, 126/255f, 219/255f);

//okay, let's get the drawings and then the stroke data for the heartLayer, whereby we can change the color??
Console.WriteLine(heartLayer.Drawings[0].Data.Strokes[0].Vertices.Count);

var stroke1Vertices = heartLayer.Drawings[0].Data.Strokes[0].Vertices;

Console.WriteLine(heartLayer.Drawings[0].Data.Strokes[0].Vertices[0].Color);
var blueVertices = new List<Vertex>();
var enlargedVertices = new List<Vertex>();
for(int i=0; i<stroke1Vertices.Count; i++)
{
  var enlargeRef = bigHeart.Drawings[0].Data.Strokes[0].Vertices[i];
  var blueRef = blueHeart.Drawings[0].Data.Strokes[0].Vertices[i];
  blueRef.Color = blue;
  blueVertices.Add(blueRef);
  //NOTE: these are SharpQuill Vector3s, that's why you can't multiply them!!
  enlargeRef.Position.X *= 3;
  enlargeRef.Position.Y *= 3;
  enlargeRef.Position.Z *= 3;
  enlargeRef.Width *= 2;

  enlargedVertices.Add(enlargeRef);
}




/*
 --------------------------------------------------------------------------------------------
ANIMATION TIMELINE STUFF IS BELOW HERE
----------------------------------------------------------------------------------------
sequence.RootLayer.FindChild(userAnswer);
 
 
 
 
 
 */


//OBVIOUSLY BETTER WAYS TO DO THIS BUT FOR NOW COPYING AND PASTING FROM BLENDSHAPES STARTER-- NEED BETTER LONGER TERM SOLUTION-- ALSO NEED TO LOOK INTO PYTHON STUFF SOONER RATHER THAN LATER!!
//
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

LayerName(sequence.RootLayer);
//So, layerPaints with different drawings by frames VS keyframes, that often have just one drawing (but may have multiple)
var singleAnimLayer = (LayerPaint)sequence.RootLayer.FindChild("Anim-key1_yel");

//so the below just has 1 drawing, 1 frame
Console.WriteLine(singleAnimLayer.Drawings.Count);
Console.WriteLine(singleAnimLayer.Frames.Count);

//and then below, 20 drawings, 20 frames
/*Console.WriteLine(frameByframeAnimLayer.Drawings.Count);
Console.WriteLine(frameByframeAnimLayer.Frames.Count);
*/
//stroke0.Vertices = newVertices;
blueHeart.Drawings[0].Data.Strokes[0].Vertices = blueVertices; //jic, not sure how references work in C#
bigHeart.Drawings[0].Data.Strokes[0].Vertices = enlargedVertices;
sequence.InsertLayerAt(blueHeart, "");
sequence.InsertLayerAt(bigHeart, "");

/*
 a ftn to modify colors in Frames-bl
1. make all a base color
2. flicker colors
3. edit color scheme (so take input, change to certain output-- just hard code to test)-- Oh i combined these. Could have done a totally random flicker
but get the idea enough, could be done. So okay.
4. add in extra frames for certain frames? i dont know. semi hard coded.
 
 */

framesColorsetc();
void framesColorsetc()
{

  var origframesbl = (LayerPaint)sequence.RootLayer.FindChild("Frames-bl");
  //this is the one you make all black
  LayerPaint framesbl= JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(origframesbl));
  LayerPaint flicker = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(origframesbl));
  LayerPaint extraframes = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(origframesbl));
  framesbl.Name = "framesbl";
  flicker.Name = "flicker";
  extraframes.Name = "extraframes";



  //let's just try doubling frames?? I dunno
  //so drawings are like a set, right? of unique drawings
  //if you just insert, it's the same drawing
  //so you're really just modifying those frames
  //but there could be other uses where you have a new drawing you want to insert or whatever-- actually, for the viseme stuff later, this
  //will be really relevant, so okay. You get a little sense of it.
  var curPos = 0;
  List<int> doubledFrames = extraframes.Frames;
  for (int f = 0; f< origframesbl.Frames.Count; f++)
  {
    int val = origframesbl.Frames[f];// this was key-- seems in C# you always gotta assign separately first
    doubledFrames.Insert(curPos, val);
    curPos += 2;
  }
  extraframes.Frames = doubledFrames;
  //extraframes.Frames.Insert(1, 1); //so this works
  sequence.InsertLayerAt(extraframes, "/frames");



  //iterate through all the drawings for the layer
  for (int i = 0; i < origframesbl.Drawings.Count; i++)
  {

   


    //get all the strokes of the current drawing
    var strokes = framesbl.Drawings[i].Data.Strokes;
    var flickerstrokes = flicker.Drawings[i].Data.Strokes;
    //iterate through all the strokes of this drawing
    for (int s = 0; s < strokes.Count; s++)
    {
      //gather all the vertices of each stroke and iterate through
      var vertices = strokes[s].Vertices;
      var flickervertices = flickerstrokes[s].Vertices;
      

      for (int v=0; v < vertices.Count; v++)
      {
        //change the color of each of those vertices to, in this case, black
        Color black = new Color(0, 0, 0);
        var curVert = vertices[v];
        curVert.Color = black;
       Console.WriteLine("vertices[v]: " + vertices[v].Color);
        vertices[v] = curVert; //oh, assignment is weird... so only worked once I did this. okay...i guess assignment doesn't work for nested shit.

        //for the flicker, see what color the vertex is first, and have a rule for changing
        var curFlickVert = flickervertices[v];
        if(curFlickVert.Color.R == 0.52033985f)
        {
          curFlickVert.Color = new Color(0, 1, 0);
          flickervertices[v] = curFlickVert;

        }
        else if (curFlickVert.Color.R  == .5530473f)
        {
          curFlickVert.Color = new Color(0, 0.5f, 0);
          flickervertices[v] = curFlickVert;
        }
        else
        {
          curFlickVert.Color = new Color(1, 0, 0);
          flickervertices[v] = curFlickVert;
        }
        
       // Console.WriteLine("r: " + curFlickVert.Color.R);

        
      }

    }
  }

  sequence.InsertLayerAt(framesbl, "/frames");
  sequence.InsertLayerAt(flicker, "/frames");
}



/*
 non-nested animkey
1. change spaces of keyframes in a layer
2. change transforms (e.g. pos, scale, rot)
 */

keyframAnimManips();
void keyframAnimManips()
{
  //will start this tomorrow
  var keyAnimLayer = (LayerPaint)sequence.RootLayer.FindChild("Anim-key1_yel"); //hard coding for now
  LayerPaint keyanimspaces = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(keyAnimLayer));
  keyanimspaces.Name = "movingTrans";
  LayerPaint keyanimtransforms = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(keyAnimLayer));
  keyanimtransforms.Name = "changeTransValues";

  //for keyanimspaces first
  //let's say we want to double the spaces between them, huh?
  //need to get to the animation for the LayerPaint, then get to the keys, then select all the transform keys
  //and then from there can iterate through the times, so to make twice as fast, you'll just divide all the times by 2 and to make slow, mult by 2
  //THIS MIGHT BE USEFUL AS A MINI TOOL ON ITS OWN, TBH

  var transforms = keyanimspaces.Animation.Keys.Transform;
  
  for(int i = 0; i<transforms.Count; i++)
  {
    keyanimspaces.Animation.Keys.Transform[i].Time = transforms[i].Time * 2;
    var transformVal = keyanimtransforms.Animation.Keys.Transform[i].Value;

    //keyanimtransforms.Animation.Keys.Transform[i].Value.Scale = 2; //THis will give errors, see note below
    //NOTE: TO CHANGE TRANSFORMS, you can't change directly parts of the value. You just have to make a whole new Transform.
    //THIS IS BC-- Transform class is a value type struct, which means it's pointing to copies of values, not the values themselves
    //So you can't change aspects of transform directly, you have to assign to a new transform, which I suppose is safer? idk
    SharpQuill.Quaternion rot = transformVal.Rotation;
    float scale = transformVal.Scale * 2;
    string flip = transformVal.Flip;

    var newX = transformVal.Translation.X + 2;
    var newY = transformVal.Translation.Y*2;
    var newZ = transformVal.Translation.Z*10;
    SharpQuill.Vector3 trans = new SharpQuill.Vector3(newX, newY, newZ);
    if (i % 2 > 0) {
      keyanimtransforms.Animation.Keys.Transform[i].Value = new Transform(rot, scale, flip, trans);
    }
  }

  //now keyanimstransforms, maybe changing position, scale, etc.


  sequence.InsertLayerAt(keyanimspaces, "/keyanims");
  sequence.InsertLayerAt(keyanimtransforms, "/keyanims");
}



/*
 * animkey sequence
 * 1. change offset
 * 2. changing spacing of keyframes and then change sequence to correspond with that
 
 
 */
sequenceChanges();

void sequenceChanges()
{
  LayerGroup seqLayer = (LayerGroup)sequence.RootLayer.FindChild("Anim-key-seq-or");
  Console.WriteLine(seqLayer.Animation);//hard coding for now
  LayerPaint animLayer = (LayerPaint)seqLayer.FindChild("Anim-key");
  Layer seqGenLayer = (Layer)seqLayer;
  
  //Need to make a layer group, and then add the children. That's what I'm thinking.
  //So let's make a new layer group, then add all the layer info from sequence data?? 
  Layer seqLayerCopy = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(seqGenLayer));



  LayerPaint animLayerCopy = JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(animLayer));
  // seqLayerCopy.Name = "edited-sequence";
  //animLayerCopy.Name = "edited anim layer";
  //First just make sure it gets copied properly-- like, the sequence is still a sequence, etc.


  //sequence.InsertLayerAt(seqLayerCopy, "");
  //sequence.InsertLayerAt(animLayerCopy, "/edited-sequence");

}



/*
 puppeteering
1. speeding up
2. slowing down
 
 */

//Below to test insertion-- it's works
//sequence.InsertLayerAt(newBlankLayer, "");


//testing to see if we can edit the same file!
//FINDING: you can't edit and see changes while working on them! Changes to json manifest file Quill.json only seen after
//So I'm thinking-- a library of particle effects-- add to existing file (_withparticleeffects) or a new file, and can modify
//potentially could then continue modifying outside of quill with a dialogue system, but since changes can't be seen while using, probably not super helpful-- like, would have to close and
//reopen file you're working in each time
//someone mentioned this in the chat-- I was searching through about particle effects
//Also: makes most sense to do this with pre-populated particle effects, right? so issue there is do you want to share since would be based off hand-drawn, something to consider-- maybe should be an internal tool?
//will be using sharpquill- did a lot of work making qbin info accessible, which I have no intention of trying tor eplicate since just figuring out to properly use is enough of a challenge for me!
//and console-based dialogue system-- eventual goal would be a python wrapper to a .NET lib (sharpquill) and then python gui, but might take me a while to figure out how to do those, but could share
//does this sound like it might be useful? As a hobbyist who I suppose never really thinks about vfx, I've only used poorly implemented rain (I followed Goro's video tutorial)
//would be many steps/layers of experimentation before I'd get to the end goal, which might effect goal itself. but

//changing heart shape
//changing heart size
//changing heart position
//Then, keyframe or puppeteer heart
//and try to change in that way

//wondering if it's useful, whether it might make more sense to have a particles library but editing still happens in Quill
//next steps: create a base quill file of particle effects. I can create myself using Goro's video tutorial on particle effects, but they will be v. poorly implemented

QuillSequenceWriter.Write(sequence, "C:\\Users\\amkas\\OneDrive\\Documents\\Quill\\part-heart-test1");
Console.WriteLine("I ran this code");



/*class ParticleCreator
{
  static void Main()
  {
    //What if I set it up, without draw info, and then it gets added later??
    //also explore, can you edit while in Quill? like, from external editor?
    //Can you add dialogue to Quill directly?? No, I don't see how
    //OKay so another way to think about it: a library of particle effects
    //and then a little dialogue system, choosing which particle effects you are adding to file, and modifying based on
    //the effect-- eg changing color, etc.
    //would be nice to change as using quill, so i do want to test that out
    //need to have a locked, read only version of the library though
    //could also come with instructions for use for each one
    //workflow-- create particle effects using Goro's tutorial
    //BUT FIRST-- something very simple, and can you edit first let's say:
    //A broken heart
    //COLOR, then
    //SCALE of objects
    //stroke duration then
    // TIMING of something in a sequence
    //can I change one thing-- let's say the size, or fi color not impossible, and write to a new file with same name thereby replacing??




  }


}
*/
