using System.Collections.Generic;
using UnityEngine;

public class WayPoint
{
    public Vector3 Position;
    public Quaternion Rotation;

    public WayPoint(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }
}

public class WayPointTracker : MonoBehaviour
{
    public List<WayPoint> pointList = new List<WayPoint>();

    // Fixed Timestamp에 설정된 값에 따라 일정 시간마다 호출 (매프레임X)
    private void FixedUpdate()
    {
        UpdateWayPoint();
    }

    public void UpdateWayPoint()
    {
        pointList.Add(new WayPoint(transform.position, transform.rotation));
    }

    public WayPoint PopWayPoint()
    {
        WayPoint point = pointList[0];
        pointList.RemoveAt(0);
        return point;
    }

    public void ClearWayPoint()
    {
        pointList.Clear();
        pointList.Add(new WayPoint(transform.position, transform.rotation));
    }
}
