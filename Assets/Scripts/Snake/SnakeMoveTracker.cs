using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakePoint
{
    public Vector3 Position;
    public Quaternion Rotation;
    public float DistanceBetweenPrev;

    public SnakePoint(Vector3 position, Quaternion rotation, float distanceBetweenPrev)
    {
        Position = position;
        Rotation = rotation;
        DistanceBetweenPrev = distanceBetweenPrev;
    }
}

public class SnakeMoveTracker : MonoBehaviour
{
    [SerializeField] private bool debug;
    [SerializeField] private LineRenderer debugLine;
    
    [SerializeField] private float Length;
    [SerializeField] private float MaxLength;

    private List<SnakePoint> SnakePoints = new List<SnakePoint>();

    #region Unity Events
    [System.Obsolete]
    private void Awake()
    {
        if (debug)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            debugLine.sortingLayerID = renderer.sortingLayerID;
            debugLine.sortingOrder = renderer.sortingOrder + 1;
            debugLine.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        UpdateLine();

        if (Length > MaxLength)
        {
            RemoveLine();
        }

        if (debug)
        {
            debugLine.positionCount = SnakePoints.Count;
            debugLine.SetPositions(SnakePoints.Select(x => x.Position).ToArray());
        }
    }
    #endregion

    #region Public Methods
    public void SetMaxLength(float maxLength)
    {
        MaxLength = maxLength;
    }
    
    public SnakePoint GetNearestPoint(float distance)
    {
        float capture = 0f;

        foreach (var point in SnakePoints)
        {
            capture += point.DistanceBetweenPrev;

            if (distance <= capture)
            {
                return point;
            }
        }

        return null;
    }
    #endregion

    #region Private Methods
    private void UpdateLine()
    {
        Vector2 newPosition = transform.position;
        float distanceBetweenPrev = 0f;
        
        if (SnakePoints.Count > 0)
        {
            distanceBetweenPrev = Vector2.Distance(newPosition, SnakePoints[SnakePoints.Count - 1].Position);
        }

        Length += distanceBetweenPrev;

        SnakePoint newPoint = new SnakePoint(transform.position, transform.rotation, distanceBetweenPrev);
        SnakePoints.Add(newPoint);
    }

    private void RemoveLine()
    {
        while (Length > MaxLength)
        {
            SnakePoint lastPoint = SnakePoints[0];
            Length -= Vector2.Distance(lastPoint.Position, SnakePoints[1].Position);

            SnakePoints.RemoveAt(0);
        }
    }
    #endregion
}
