using UnityEngine;

[RequireComponent(typeof(SnakeMovement))]
[RequireComponent(typeof(SnakeBodyParts))]
public class Snake : MonoBehaviour
{
    private SnakeBodyParts bodyParts;
    private ExpManager expManager;

    private void Start()
    {
        bodyParts = GetComponent<SnakeBodyParts>();
        
        expManager = GetComponent<ExpManager>();
        expManager.OnLevelUp.AddListener(OnLevelUp);
    }

    public void OnCollision(Collider2D collider)
    {
        GameObject gameObject = collider.gameObject;

        if (gameObject.CompareTag("Feed"))
        {
            float exp = gameObject.GetComponent<Feed>().exp;
            expManager.AddExp(exp);

            Destroy(gameObject);
        }
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up!!");
        bodyParts.AppendParts();
    }
}
