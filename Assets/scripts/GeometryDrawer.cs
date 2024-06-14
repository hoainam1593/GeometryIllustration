using System.Collections.Generic;
using UnityEngine;

public class GeometryDrawer
{
    private static void CreateLineRenderer(List<Vector2> lPoints)
    {
		//spawn
		var prefab = Resources.Load<LineRenderer>("line-unit/line-unit");
		var line = Object.Instantiate(prefab);

		//set points
		line.positionCount = lPoints.Count;
		for (var i = 0; i < lPoints.Count; i++)
		{
			line.SetPosition(i, lPoints[i]);
		}

		//set width
		var lineThickness = GeometryDrawerConfig.instance.lineThickness;
		line.startWidth = lineThickness;
		line.endWidth = lineThickness;
	}

	public static void DrawLine(Vector2 p1, Vector2 p2)
	{
		CreateLineRenderer(new List<Vector2>() { p1, p2 });
	}

	public static void DrawTriangle(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		CreateLineRenderer(new List<Vector2>() { p1, p2, p3, p1 });
	}

	public static void DrawCircle(Vector2 center, float radius)
	{
		var res = GeometryDrawerConfig.instance.circleResolution;
		var pieceAngle = (2 * Mathf.PI) / res;
		var lPoints = new List<Vector2>();
		for (var i = 0; i <= res; i++)
		{
			var p = new Vector2(Mathf.Cos(i * pieceAngle), Mathf.Sin(i * pieceAngle));
			p *= radius;
			p += center;
			lPoints.Add(p);
		}
		CreateLineRenderer(lPoints);
	}
}
