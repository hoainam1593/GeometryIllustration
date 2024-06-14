using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		GeometryDrawer.DrawLine(new Vector2(2, 3), new Vector2(-1, 2));
		GeometryDrawer.DrawCircle(new Vector2(-1, -2), 2);
	}
}
