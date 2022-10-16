using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField]
    private GameObject BodyPrefab;
    [SerializeField]
    private int BodyCount;
    [SerializeField]
    private float DistanceBetween = 0.25f;

    private Snake SnakeHead;
    private SnakeMoveTracker MoveTracker;
    private List<GameObject> BodyParts = new List<GameObject>();

    #region Unity Events
    private void Start()
    {
        SnakeHead = GetComponentInParent<Snake>();
        MoveTracker = GetComponentInParent<SnakeMoveTracker>();

        SetTrackingLength();
    }

    private void FixedUpdate()
    {
        if (BodyParts.Count < BodyCount)
        {
            AppendBodyByTracker();
        }

        for (int index = 0; index < BodyParts.Count; index++)
        {
            Movement(index);
        }
    }
    #endregion

    #region Public Methods
    public void Append()
    {
        ++BodyCount;
    }

    public void SetSkin(Color skin)
    {
        foreach (GameObject item in BodyParts)
        {
            item.GetComponent<SpriteRenderer>().color = skin;
        }
    }
    #endregion

    #region Private Methods
    private void SetTrackingLength()
    {
        MoveTracker.SetMaxLength(DistanceBetween * (BodyCount + 1));
    }

    private void AppendBodyByTracker()
    {
        float distance = DistanceBetween * (BodyParts.Count + 1);
        SnakePoint nerestPoint = MoveTracker.GetNearestPoint(distance);
        if (nerestPoint == null)
        {
            return;
        }

        GameObject body = Instantiate(BodyPrefab, nerestPoint.Position, nerestPoint.Rotation, transform);
        body.GetComponent<SpriteRenderer>().color = SnakeHead.Skin;
        BodyParts.Add(body);

        SetTrackingLength();
    }

    private void Movement(int index)
    {
        float distance = DistanceBetween * index;
        SnakePoint nerestPoint = MoveTracker.GetNearestPoint(distance);
        if (nerestPoint == null)
        {
            return;
        }

        GameObject body = BodyParts[index];
        body.transform.position = Vector3.Lerp(body.transform.position, nerestPoint.Position, 1f * Time.deltaTime);
        body.transform.position = nerestPoint.Position;
    }
    #endregion
}
