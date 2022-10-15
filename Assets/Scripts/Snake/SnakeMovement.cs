using UnityEngine;

[RequireComponent(typeof(SnakeBodyParts))]
public class SnakeMovement : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10;
    [SerializeField]
    private float TurnSpeed = 18;

    GameObject head;
    SnakeBodyParts bodyParts;

    private void Start()
    {
        bodyParts = GetComponent<SnakeBodyParts>();
        head = bodyParts.GetParts(0);
    }

    private void FixedUpdate()
    {
        SnakeMovmenet();
    }

    private void SnakeMovmenet()
    {
        LootAtMouse();
        MoveToForward();
    }

    private void LootAtMouse()
    {
        Transform snake = head.transform;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - snake.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        Quaternion rotation = Quaternion.RotateTowards(snake.rotation, Quaternion.Euler(targetRotation), TurnSpeed * Time.deltaTime);

        head.GetComponent<Rigidbody2D>().MoveRotation(rotation);
    }

    private void MoveToForward()
    {
        head.GetComponent<Rigidbody2D>().velocity = head.transform.right * MoveSpeed * Time.deltaTime;
    }
}
