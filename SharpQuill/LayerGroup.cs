using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpQuill
{
  /// <summary>
  /// The type-specific data of a group layer.
  /// A group layer contains other layers.
  /// </summary>
  public class LayerGroup : Layer
  {
    public override LayerType Type { get { return LayerType.Group; } }

    public List<Layer> Children { get; set; } = new List<Layer>();

    /// <summary>
    /// Constructs a new group layer.
    /// </summary>
    /// <param name="name">The name of the layer.</param>
    /// <param name="isSequence">Whether this layer is an animated group.</param>
    public LayerGroup(string name = "", bool isAnimated = false)
    {
      this.Name = name;

      // Default values for a new animated group, also called a sequence in the Quill UI.
      if (isAnimated)
      {
        Animation.Duration = 45360000;
        Animation.Timeline = true;
      }
    }

    /// <summary>
    /// Creates the default root group used in the default sequence.
    /// </summary>
    public static LayerGroup CreateDefault()
    {
      return new LayerGroup("Root", true);
    }

    /// <summary>
    /// Finds a layer at the specified path. Does not create the groups along the way if not found.
    /// </summary>
    public Layer FindLayer(string path)
    {
      string[] nodes = path.Split(new string[] { "/", "\\" }, StringSplitOptions.RemoveEmptyEntries);

      LayerGroup parent = this;
      Layer layer = parent;
      for (int i = 0; i < nodes.Length; i++)
      {
        if (parent == null)
          return null;

        Layer child = parent.FindChild(nodes[i]);
        if (child == null)
          return null;

        if (i == nodes.Length - 1)
          return child;
        else
          parent = child as LayerGroup;
      }

      return layer;
    }

    /// <summary>
    /// Finds an immediate child layer matching the name.
    /// </summary>
    public Layer FindChild(string name)
    {
      foreach (Layer child in Children)
      {
        if (child.Name != name)
          continue;

        return child;
      }

      return null;
    }

    public LayerGroup DeepCopy()
    {
      LayerGroup copy = new LayerGroup
      {
        Name = this.Name,
        Visible = this.Visible,
        Locked = this.Locked,
        Collapsed = this.Collapsed,
        BBoxVisible = this.BBoxVisible,
        Opacity = this.Opacity,
        IsModelTopLayer = this.IsModelTopLayer,
        KeepAlive = this.KeepAlive,
        Transform = this.Transform,
        Animation = this.Animation,
        // DeepCopy the children with correct types
        Children = this.Children.Select(child =>
        {
          if (child is LayerPaint paintChild)
            return JsonConvert.DeserializeObject<LayerPaint>(JsonConvert.SerializeObject(paintChild));
          // Add other types if needed
          else if (child is LayerGroup groupChild)
            return groupChild.DeepCopy();
          else if (child is LayerCamera camChild)
            return JsonConvert.DeserializeObject<LayerCamera>(JsonConvert.SerializeObject(camChild));
          else if (child is LayerPicture picChild)
            return JsonConvert.DeserializeObject<LayerPicture>(JsonConvert.SerializeObject(picChild));
          else if (child is LayerSound soundChild)
            return JsonConvert.DeserializeObject<LayerSound>(JsonConvert.SerializeObject(soundChild));
          else if (child is LayerViewpoint viewChild)
            return JsonConvert.DeserializeObject<LayerViewpoint>(JsonConvert.SerializeObject(viewChild));
          // Default: return a shallow copy if type is not recognized
          return (Layer)child.ShallowCopy(child.Name);
        }).ToList()
      };

      return copy;
    }

  }
}
