using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		Drawing_1();
	}

	#region drawing 1

	private void ExtraDrawing_1(Vector2 pointA, Vector2 pointB)
	{
		var pointM = new Vector2(pointA.y / Mathf.Tan(Mathf.PI / 3), 0);
		var pointH = new Vector2(0, 0);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA),
			new PointInfo(pointM,"M"),
		}, Color.red);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA),
			new PointInfo(pointH,"H"),
		}, Color.red);

		GeometryDrawer.DrawAngleLabel(pointH, pointA, pointB, Color.red);
	}

	private void Drawing_1()
	{
		var sideLength = 3;

		var pointB = new Vector2(-sideLength, 0);
		var pointC = new Vector2(sideLength, 0);

		var pointHB = new Vector2(0, sideLength);
		var pointHC = new Vector2(0, sideLength * Mathf.Tan(Mathf.PI / 6));

		var lineHB = new Line(pointB, pointHB);
		var lineHC = new Line(pointC, pointHC);

		var pointA = lineHB.Intersect(lineHC).Value;

		var moveX = pointA.x;

		pointA.x -= moveX;
		pointB.x -= moveX;
		pointC.x -= moveX;

		GeometryDrawer.DrawTriangle(new List<PointInfo>()
		{
			new PointInfo(pointA,"A"),
			new PointInfo(pointB,"B"),
			new PointInfo(pointC,"C"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointB, pointA, pointC, Color.black);
		GeometryDrawer.DrawAngleLabel(pointC, pointA, pointB, Color.black);

		var vBC = (pointC - pointB).normalized;
		var BC = Vector2.Distance(pointB, pointC);
		var BD = BC / Mathf.Pow(12, 0.25f);
		var pointD = pointB + BD * vBC;
		var pointE = new Vector2(0, Mathf.Tan(Mathf.PI / 3) * pointD.x);

		var lineED = new Line(pointE, pointD);
		var lineAB = new Line(pointA, pointB);
		pointE = lineED.Intersect(lineAB).Value;

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointE, "E"),
			new PointInfo(pointD, "D"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointD, pointE, pointB, Color.black);

		ExtraDrawing_1(pointA, pointB);
	}

	#endregion
}
