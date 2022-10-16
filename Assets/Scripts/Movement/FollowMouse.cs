using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 100;
    [SerializeField]
    private float TurnSpeed = 180;

    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), TurnSpeed * Time.deltaTime);

        rigidBody.MoveRotation(rotation);
    }

    private void MoveToForward()
    {
        rigidBody.velocity = transform.right * MoveSpeed * Time.deltaTime;
    }
}
