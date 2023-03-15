using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("AI/Waypoints/Waypoints Path")]
public sealed class WaypointsPath : MonoBehaviour
{
    public List<Transform> GetTransformPoints()
    {
        var points = new List<Transform>();
        foreach (Transform point in transform)
        {
            if (point.gameObject.activeSelf)
            {
                points.Add(point);
            }
        }

        return points;
    }

    public List<Vector3> GetPositionPoints()
    {
        var points = new List<Vector3>();
        foreach (Transform point in transform)
        {
            if (point.gameObject.activeSelf)
            {
                points.Add(point.position);
            }
        }

        return points;
    }

#if UNITY_EDITOR

    [SerializeField]
    private bool _drawGizmos;

    [SerializeField]
    private bool _loop;

    [SerializeField]
    private Color _color = Color.red;

    private void OnDrawGizmos()
    {
        if (_drawGizmos)
        {
            var points = GetTransformPoints();
            WaypointsPathGizmos.DrawRoads(points, _loop, _color);
        }
    }
#endif
}
