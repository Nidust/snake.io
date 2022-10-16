using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SnakeCollider : MonoBehaviour
{
    [SerializeField]
    private Snake snake;
    private bool hitHead;
    
    private void Awake()
    {
        snake = GetComponentInParent<Snake>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (snake == null)
        {
            return;
        }

        if (collider.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collider.gameObject.CompareTag("Feed"))
        {
            snake.EatFeed(collider.gameObject.GetComponent<Feed>());
        }
    }
}
