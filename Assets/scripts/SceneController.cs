using UnityEngine;

public class SceneController : MonoBehaviour
{
	private void Start()
	{
		GeometryDrawer.DrawTriangle(new Vector2(-1, 0), new Vector2(2, 0), new Vector2(0, 3));
	}
}
