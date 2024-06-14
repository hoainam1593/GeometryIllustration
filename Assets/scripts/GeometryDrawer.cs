using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeometryDrawer
{
    private static void CreateLineRenderer(List<Vector2> lPoints, Color color)
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

		//set color
		line.material.color = color;
	}

	private static void CreateText(string str, Vector2 pos)
	{
		var prefab = Resources.Load<TextMeshPro>("text");
		var text = Object.Instantiate(prefab);
		text.transform.position = pos;
		text.text = str;
	}

	public static void DrawLine(List<PointInfo> lPoints, Color color)
	{
		var dist = GeometryDrawerConfig.instance.textPointDistance;
		var lPos = new List<Vector2>();
		for (var i = 0; i < lPoints.Count; i++)
		{
			if (!string.IsNullOrEmpty(lPoints[i].label))
			{
				var p1 = lPoints[i].p;
				var p2 = lPoints[1 - i].p;
				var v = (p1 - p2).normalized;
				CreateText(lPoints[i].label, p1 + dist * v);
			}
			lPos.Add(lPoints[i].p);
		}

		CreateLineRenderer(lPos, color);
	}

	public static void DrawTriangle(List<PointInfo> lPoints, Color color)
	{
		var dist = GeometryDrawerConfig.instance.textPointDistance;
		var lPos = new List<Vector2>();
		for (var i = 0; i < lPoints.Count; i++)
		{
			if (!string.IsNullOrEmpty(lPoints[i].label))
			{
				var p0 = lPoints[i].p;
				var p1Idx = i - 1 >= 0 ? i - 1 : i + 1;
				var p1 = lPoints[p1Idx].p;
				var p2 = lPoints[3 - p1Idx - i].p;
				var pm = (p1 + p2) / 2;
				var v = (p0 - pm).normalized;
				CreateText(lPoints[i].label, p0 + dist * v);
			}
			lPos.Add(lPoints[i].p);
		}
		lPos.Add(lPoints[0].p);

		CreateLineRenderer(lPos, color);
	}

	public static void DrawCircle(Vector2 center, float radius, Color color)
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
		CreateLineRenderer(lPoints, color);
	}
}
