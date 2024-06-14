using UnityEngine;

public class Line
{
    private float coefficientA;
	private float coefficientB;
	private float coefficientC;

	public Line(Vector2 p1, Vector2 p2)
    {
		if (p1.x == p2.x)
		{
			coefficientA = 1;
			coefficientB = 0;
			coefficientC = -p1.x;
		}
		else if (p1.y == p2.y)
		{
			coefficientA = 0;
			coefficientB = 1;
			coefficientC = -p1.y;
		}
		else
		{
			coefficientA = 1 / (p2.x - p1.x);
			coefficientB = -1 / (p2.y - p1.y);
			coefficientC = -p1.x / (p2.x - p1.x) + p1.y / (p2.y - p1.y);
		}
    }

	public Vector2? Intersect(Line line)
	{
		var t = coefficientA * line.coefficientB - coefficientB * line.coefficientA;
		if (t == 0)
		{
			return null;
		}
		var x = (coefficientB * line.coefficientC - coefficientC * line.coefficientB) / t;
		var y = -(coefficientA * line.coefficientC - coefficientC * line.coefficientA) / t;
		return new Vector2(x, y);
	}
}
