using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static List<float> SolveQuadraticEquation(float a, float b, float c)
    {
        var solutions = new List<float>();
        var delta = b * b - 4 * a * c;
        if (delta > 0)
        {
            var squareRootDelta = Mathf.Sqrt(delta);
            solutions.Add((-b + squareRootDelta) / (2 * a));
            solutions.Add((-b - squareRootDelta) / (2 * a));
        }
        else if (delta == 0)
        {
            solutions.Add(-b / (2 * a));
        }
        return solutions;
    }
}
