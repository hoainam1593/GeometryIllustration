
using UnityEngine;

public class PointInfo
{
    public Vector2 p;
    public string label = null;

    public PointInfo(Vector2 p, string label)
    {
        this.p = p;
        this.label = label;
    }

    public PointInfo(Vector2 p)
    {
		this.p = p;
	}
}
