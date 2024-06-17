using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		Drawing_1();
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

		var pointD = new Vector2(pointA.y / Mathf.Tan(Mathf.PI / 3), 0);

		GeometryDrawer.DrawTriangle(new List<PointInfo>()
		{
			new PointInfo(pointA,"A"),
			new PointInfo(pointB,"B"),
			new PointInfo(pointC,"C"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointB, pointA, pointC, Color.black);
		GeometryDrawer.DrawAngleLabel(pointC, pointA, pointB, Color.black);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA),
			new PointInfo(pointD,"D"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointD, pointA, pointB, Color.black);

		var pointH = new Vector2(0, 0);

		GeometryDrawer.DrawLine(new List<PointInfo>()
		{
			new PointInfo(pointA),
			new PointInfo(pointH,"H"),
		}, Color.black);

		GeometryDrawer.DrawAngleLabel(pointH, pointA, pointB, Color.black);
	}
}
