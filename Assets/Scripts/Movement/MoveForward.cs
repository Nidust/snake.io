using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 2f;

    private Rigidbody2D RigidBody;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = transform.position.x + MoveSpeed * Time.deltaTime;
        float y = Mathf.Sin(Time.time * MoveSpeed) * 0.5f;
        
        RigidBody.MovePosition(new Vector2(x, y));
    }
}
