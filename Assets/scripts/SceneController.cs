using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		var a = new Vector2(-3, 1);
		var b = new Vector2(1, -1);

		var c = new Vector2(-1, 2);
		var d = new Vector2(-2, -2);

		GeometryDrawer.DrawLine(new System.Collections.Generic.List<PointInfo>() {
			new PointInfo(a),
			new PointInfo(b),
		}, Color.green);

		GeometryDrawer.DrawLine(new System.Collections.Generic.List<PointInfo>() {
			new PointInfo(c),
			new PointInfo(d),
		}, Color.magenta);

		GeometryDrawer.DrawCircle(new Vector2(0, 0), 2, Color.cyan);

		var line1 = new Line(a, b);
		var line2 = new Line(c, d);

		var p = line1.Intersect(line2);

		Debug.LogError($"{p.Value.x}, {p.Value.y}");
	}
}
