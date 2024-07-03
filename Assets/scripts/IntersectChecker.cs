using System.Collections.Generic;
using UnityEngine;

public class IntersectChecker
{
    public static Vector2? Line_Line(Line line1, Line line2)
    {
		var t = line1.coefficientA * line2.coefficientB - line1.coefficientB * line2.coefficientA;
		if (t == 0)
		{
			return null;
		}
		var x = (line1.coefficientB * line2.coefficientC - line1.coefficientC * line2.coefficientB) / t;
		var y = -(line1.coefficientA * line2.coefficientC - line1.coefficientC * line2.coefficientA) / t;
		return new Vector2(x, y);
	}

	public static List<Vector2> Line_Circle(Line line, Circle circle)
	{
		if (line.coefficientA != 0)
		{
			var m = -line.coefficientB / line.coefficientA;
			var n = -line.coefficientC / line.coefficientA - circle.center.x;

			var solutions = Utils.SolveQuadraticEquation(
				m * m + 1,
				2 * m * n - 2 * circle.center.y,
				n * n + circle.center.y * circle.center.y - circle.radius * circle.radius);

			var intersectPoints = new List<Vector2>();
			foreach (var y in solutions)
			{
				var x = m * y - line.coefficientC / line.coefficientA;
				intersectPoints.Add(new Vector2(x, y));
			}
			return intersectPoints;
		}
		else
		{
			var y = -line.coefficientC / line.coefficientB;
			var m = y - circle.center.y;
			var n = circle.radius * circle.radius - m * m;

			var intersectPoints = new List<Vector2>();
			if (n > 0)
			{
				var x = circle.center.x + Mathf.Sqrt(n);
				intersectPoints.Add(new Vector2(x, y));

				x = circle.center.x - Mathf.Sqrt(n);
				intersectPoints.Add(new Vector2(x, y));
			}
			else if (n == 0)
			{
				var x = circle.center.x;
				intersectPoints.Add(new Vector2(x, y));
			}
			return intersectPoints;
		}
	}
}
