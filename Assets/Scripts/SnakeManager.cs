using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField]
    private float distanceBetween = .2f;
    [SerializeField]
    private float MoveSpeed = 10;
    [SerializeField]
    private float TurnSpeed = 18;
    [SerializeField]
    private List<GameObject> BodyParts = new List<GameObject>();

    GameObject snakeHead;
    List<GameObject> snakeBody = new List<GameObject>();

    float countUp = 0;

    private void Start()
    {
        CreateBodyParts();
    }

    private void FixedUpdate()
    {
        if (BodyParts.Count > 0)
        {
            CreateBodyParts();
        }

        SnakeMovmenet();
    }

    private void CreateBodyParts()
    {
        if (snakeBody.Count == 0)
        {
            snakeHead = CreateBody(transform.position, transform.rotation);
            BodyParts.RemoveAt(0);
        }

        WayPointTracker tracker = snakeBody[snakeBody.Count - 1].GetComponent<WayPointTracker>();
        if (countUp == 0)
        {
            tracker.ClearWayPoint();
        }

        countUp += Time.deltaTime;
        if (countUp >= distanceBetween)
        {
            GameObject newBody = CreateBody(tracker.pointList[0].Position, tracker.pointList[0].Rotation);
            newBody.GetComponent<WayPointTracker>().ClearWayPoint();

            BodyParts.RemoveAt(0);
            countUp = 0;
        }
    }

    private GameObject CreateBody(Vector3 position, Quaternion rotation)
    {
        GameObject newBody = Instantiate(BodyParts[0], position, rotation, transform);

        if (newBody.GetComponent<WayPointTracker>() == false)
        {
            newBody.AddComponent<WayPointTracker>();
        }

        if (newBody.GetComponent<Rigidbody2D>() == false)
        {
            Rigidbody2D rigidbody = newBody.AddComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        snakeBody.Add(newBody);
        return newBody;
    }

    private void SnakeMovmenet()
    {
        LootAtMouse();
        MoveToForward();

        if (snakeBody.Count > 1)
        {
            SnakeBodysMovementByTracker();
        }
    }

    private void LootAtMouse()
    {
        Transform snake = snakeBody[0].transform;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - snake.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        Quaternion rotation = Quaternion.RotateTowards(snake.rotation, Quaternion.Euler(targetRotation), TurnSpeed * Time.deltaTime);

        snakeBody[0].GetComponent<Rigidbody2D>().MoveRotation(rotation);
    }

    private void MoveToForward()
    {
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * MoveSpeed * Time.deltaTime;
    }

    private void SnakeBodysMovementByTracker()
    {
        for (int index = 1; index < snakeBody.Count; index++)
        {
            WayPointTracker tracker = snakeBody[index - 1].GetComponent<WayPointTracker>();

            snakeBody[index].transform.position = tracker.pointList[0].Position;
            snakeBody[index].transform.rotation = tracker.pointList[0].Rotation;

            tracker.pointList.RemoveAt(0);
        }
    }
}
