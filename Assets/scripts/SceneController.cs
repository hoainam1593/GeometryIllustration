using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		var p1 = new Vector2(1, 0);
		var p2 = new Vector2(1, 1);

		GeometryDrawer.DrawAngleLabel(new Vector2(0, 0),
			p1, p2, Color.black);

		GeometryDrawer.DrawLine(new System.Collections.Generic.List<PointInfo>()
		{
			new PointInfo(new Vector2(0,0)),
			new PointInfo(p1)
		}, Color.black);

		GeometryDrawer.DrawLine(new System.Collections.Generic.List<PointInfo>()
		{
			new PointInfo(new Vector2(0,0)),
			new PointInfo(p2)
		}, Color.black);
	}
}
