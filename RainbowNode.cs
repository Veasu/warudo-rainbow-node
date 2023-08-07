using UnityEngine;
using Warudo.Core;
using Warudo.Core.Attributes;

namespace veasu.rainbow
{
  [NodeType(Id = "com.veasu.rainbownode", Title = "Rainbow Node", Category = "Colour Nodes")]
  public class RainbowNode : Warudo.Core.Graphs.Node
  {
    [DataInput]
    [Label("Speed")]
    public float speed = 0;

    [DataInput]
    [Label("Saturation")]
    public float sat = 0;

    [DataInput]
    [Label("Brightness")]
    public float val = 0;

    [DataOutput]
    [Label("Colour")]
    private Color getOutputColour() {
      return rbgColor;
    }

    private Color rbgColor = new Color();

    private float NormalPingPong(float length, float pingPongPeriod = 1f)
    {
      Debug.Log(pingPongPeriod);
      float time = Time.time;
      float mod = time % pingPongPeriod;
      float result = (mod < pingPongPeriod / 2f) ? mod : pingPongPeriod - mod;
      return result / pingPongPeriod * length * 2;
    }

    public override void OnUpdate() {
      rbgColor = Color.HSVToRGB(Mathf.Lerp(0, 1, NormalPingPong(1.0f, 10.0f / speed)), sat, val);
    }
  }

}
