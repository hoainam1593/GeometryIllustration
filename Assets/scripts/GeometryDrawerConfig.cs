using UnityEngine;
using System;
[CreateAssetMenu(fileName = "GeometryDrawerConfig", menuName = "Configs/GeometryDrawerConfig", order = 1)]
public class GeometryDrawerConfig : ScriptableObject
{
	[Serializable]
	public class AngleLabel
	{
		public float arcRadius;
		public float arcRadiusOrthogonal;
		public float textPointDistance;
	}

	public float lineThickness;
	public int circleResolution;
	public float textPointDistance;
	public AngleLabel angleLabel;

	public static GeometryDrawerConfig instance => Resources.Load<GeometryDrawerConfig>("GeometryDrawerConfig");
}
