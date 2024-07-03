using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		//Drawing_1();
		Drawing_2();
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

		var pointA = IntersectChecker.Line_Line(lineHB, lineHC).Value;

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
		pointE = IntersectChecker.Line_Line(lineED, lineAB).Value;

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointE, "E"),
			new PointInfo(pointD, "D"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointD, pointE, pointB, Color.black);

		ExtraDrawing_1(pointA, pointB);
	}

	#endregion

	#region drawing 2

	private void Drawing_2()
	{
		var pointO = Vector2.zero;
		var circle = new Circle(pointO, 2);

		GeometryDrawer.DrawCircle(circle.center, circle.radius, Color.black);

		var pointM = new Vector2(4, -1);
		var point = new Vector2(3, -1);
		var line = new Line(pointM, point);
		var intersectPoints = IntersectChecker.Line_Circle(line, circle);

		var pointA = intersectPoints[0];
		var pointB = intersectPoints[1];
		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA,"A"),
			new PointInfo(pointB,"B"),
		}, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(intersectPoints[0]),
			new PointInfo(pointM),
		}, Color.black);

		point = new Vector2(0, 2.1f);
		line = new Line(pointM, point);
		intersectPoints = IntersectChecker.Line_Circle(line, circle);

		var pointC = intersectPoints[0];
		var pointD = intersectPoints[1];
		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointC,"C"),
			new PointInfo(pointD,"D"),
		}, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(intersectPoints[0]),
			new PointInfo(pointM),
		}, Color.black);

		var lineAD = new Line(pointA, pointD);
		var lineBC = new Line(pointB, pointC);
		var pointN = IntersectChecker.Line_Line(lineAD, lineBC).Value;

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointN),
			new PointInfo(pointA),
		}, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointN),
			new PointInfo(pointB),
		}, Color.black);

		var lineAC = new Line(pointA, pointC);
		var lineBD = new Line(pointB, pointD);
		var pointI = IntersectChecker.Line_Line(lineAC, lineBD).Value;

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA),
			new PointInfo(pointC),
		}, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointB),
			new PointInfo(pointD),
		}, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointO,"O"),
			new PointInfo(pointI,"I"),
		}, Color.red);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointM, "M"),
			new PointInfo(pointN, "N"),
		}, Color.red);

	}

	#endregion
}
