using UnityEngine;

public class Line
{
    public float coefficientA;
	public float coefficientB;
	public float coefficientC;

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
}
