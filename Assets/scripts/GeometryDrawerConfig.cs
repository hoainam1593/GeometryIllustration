using UnityEngine;

[CreateAssetMenu(fileName = "GeometryDrawerConfig", menuName = "Configs/GeometryDrawerConfig", order = 1)]
public class GeometryDrawerConfig : ScriptableObject
{
	public float lineThickness;
	public int circleResolution;

	public static GeometryDrawerConfig instance => Resources.Load<GeometryDrawerConfig>("GeometryDrawerConfig");
}
