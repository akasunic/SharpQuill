using SharpQuill;
using System;
using System.Numerics;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
//SEE CHATGPT!!! FIRST JUST TRY ANIMATING ANYTHIGN!!!! EG DO A RANDOM SCALE CHANGE, OR A DUPLICATION OR WHATE HAVE YOU


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


//stroke0.Vertices = newVertices;
blueHeart.Drawings[0].Data.Strokes[0].Vertices = blueVertices; //jic, not sure how references work in C#
bigHeart.Drawings[0].Data.Strokes[0].Vertices = enlargedVertices;
sequence.InsertLayerAt(blueHeart, "");
sequence.InsertLayerAt(bigHeart, "");


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
