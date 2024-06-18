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

	private static void CreateText(string str, Vector2 pos, Color color)
	{
		var prefab = Resources.Load<TextMeshPro>("text");
		var text = Object.Instantiate(prefab);
		text.transform.position = pos;
		text.text = str;
		text.color = color;
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
				CreateText(lPoints[i].label, p1 + dist * v, color);
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
				CreateText(lPoints[i].label, p0 + dist * v, color);
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

	#region DrawAngleLabel

	public static void DrawAngleLabel(Vector2 p1, Vector2 p2, Vector2 p3, Color color)
	{
		var v1 = (p2 - p1).normalized;
		var v2 = (p3 - p1).normalized;
		var angleInRad = Mathf.Acos(Vector2.Dot(v1, v2));
		var angleInDeg = Mathf.RoundToInt(angleInRad * 180 / Mathf.PI);

		//handle the case orthogonal
		if (angleInDeg == 90)
		{
			DrawAngleLabel_orthogonal(p1, p2, p3, color);
			return;
		}

		//draw arc
		var arcRadius = GeometryDrawerConfig.instance.angleLabel.arcRadius;
		Vector2? beginPoint = p1 + arcRadius * v1;
		Vector2? endPoint = p1 + arcRadius * v2;

		var lPointsRef = new List<Vector2?>() { beginPoint, endPoint };
		CreateArcMiddlePoint(lPointsRef, angleInRad, beginPoint, endPoint, p1);

		var lPoints = new List<Vector2>();
		foreach (var i in lPointsRef)
		{
			lPoints.Add(i.Value);
		}
		CreateLineRenderer(lPoints, color);

		//draw text
		var v = (v1 + v2).normalized;
		var textDist = GeometryDrawerConfig.instance.angleLabel.textPointDistance;
		CreateText($"{angleInDeg}\u00B0", p1 + textDist * v, color);
	}

	private static void DrawAngleLabel_orthogonal(Vector2 p1, Vector2 p2, Vector2 p3, Color color)
	{
		var arcRadius = GeometryDrawerConfig.instance.angleLabel.arcRadiusOrthogonal;
		var v1 = (p2 - p1).normalized;
		var v2 = (p3 - p1).normalized;
		var lPoints = new List<Vector2>();
		lPoints.Add(p1 + arcRadius * v1);
		lPoints.Add(lPoints[0] + arcRadius * v2);
		lPoints.Add(p1 + arcRadius * v2);
		CreateLineRenderer(lPoints, color);
	}

	private static void CreateArcMiddlePoint(List<Vector2?> lPoints, float angleInRad, Vector2? beginPoint, Vector2? endPoint, Vector2 root)
	{
		var res = GeometryDrawerConfig.instance.circleResolution;
		var pieceAngle = (2 * Mathf.PI) / res;
		if (angleInRad < pieceAngle)
		{
			return;
		}

		var center = (beginPoint.Value + endPoint.Value) / 2;
		var v = (center - root).normalized;
		var arcRadius = GeometryDrawerConfig.instance.angleLabel.arcRadius;
		Vector2? centerRef = root + arcRadius * v;
		lPoints.Insert(lPoints.IndexOf(endPoint), centerRef);

		CreateArcMiddlePoint(lPoints, angleInRad / 2, beginPoint, centerRef, root);
		CreateArcMiddlePoint(lPoints, angleInRad / 2, centerRef, endPoint, root);
	}

	#endregion
}
