using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 180f;
    [SerializeField]
    private float TurnSpeed = 360f;
    [SerializeField]
    private float Circuler = 2.5f;

    private Rigidbody2D rigidBody;
    private Vector3 targetPosition;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateTargetPosition();

        LootAtTarget();
        MoveToForward();
    }

    private void UpdateTargetPosition()
    {
        float x = transform.position.x + 1f;
        float y = Mathf.Sin(Time.time * Circuler) * 0.5f;

        targetPosition = new Vector3(x, y, 0f);
    }

    private void LootAtTarget()
    {
        Vector3 direction = targetPosition - transform.position;

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
