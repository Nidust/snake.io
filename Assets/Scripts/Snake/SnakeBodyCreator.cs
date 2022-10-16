using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyCreator : MonoBehaviour
{
    [SerializeField]
    private Color skin = Color.white;
    [SerializeField]
    private float distanceBetween = 0.1f;
    [SerializeField]
    private GameObject HeadPrefab;
    [SerializeField]
    private GameObject BodyPrefab;
    [SerializeField]
    private int RequiredBeCreated;
    [SerializeField]
    private List<GameObject> BodyParts = new List<GameObject>();
    
    float time = 0f;

    private void Awake()
    {
        CreateParts();

        skin = LoginUser.instance.skin;
    }

    private void FixedUpdate()
    {
        if (RequiredBeCreated > 0)
        {
            CreateParts();
        }

        if (BodyParts.Count > 1)
        {
            SnakeBodysMovementByTracker();
        }
    }

    private void CreateParts()
    {
        if (BodyParts.Count == 0)
        {
            CreatePart(HeadPrefab, transform.position, transform.rotation);
        }

        WayPointTracker tracker = BodyParts[BodyParts.Count - 1].GetComponent<WayPointTracker>();
        if (time == 0)
        {
            tracker.ClearWayPoint();
        }

        time += Time.deltaTime;
        if (time >= distanceBetween)
        {
            GameObject newBody = CreatePart(BodyPrefab, tracker.pointList[0].Position, tracker.pointList[0].Rotation);
            newBody.GetComponent<WayPointTracker>().ClearWayPoint();

            --RequiredBeCreated;
            time = 0;
        }
    }

    private GameObject CreatePart(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newBody = Instantiate(prefab, position, rotation, transform);
        SpriteRenderer sprite = newBody.GetComponent<SpriteRenderer>();
        sprite.color = skin;

        BodyParts.Add(newBody);
        return newBody;
    }

    private void SnakeBodysMovementByTracker()
    {
        for (int index = 1; index < BodyParts.Count; index++)
        {
            WayPointTracker tracker = BodyParts[index - 1].GetComponent<WayPointTracker>();
            WayPoint point = tracker.PopWayPoint();

            BodyParts[index].transform.position = point.Position;
            BodyParts[index].transform.rotation = point.Rotation;
        }
    }

    public void SetColor(Color color)
    {
        skin = color;

        foreach (GameObject item in BodyParts)
        {
            item.GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void AppendBody()
    {
        ++RequiredBeCreated;
    }

    public GameObject GetParts(int index)
    {
        return BodyParts[index];
    }
}
