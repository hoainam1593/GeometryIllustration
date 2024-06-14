using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		GeometryDrawer.DrawTriangle(new System.Collections.Generic.List<PointInfo>() {
			new PointInfo(new Vector2(-1, 0), "A"),
			new PointInfo(new Vector2(2, 0), "B"),
			new PointInfo(new Vector2(0, 3), "C"),
		});
	}
}
