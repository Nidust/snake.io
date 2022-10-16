using UnityEngine;

[RequireComponent(typeof(SnakeBodyCreator))]
[RequireComponent(typeof(ExpManager))]
public class Snake : MonoBehaviour
{
    private SnakeBodyCreator creator;
    private ExpManager expManager;

    private GameObject snakeHead;

    private void Start()
    {
        creator = GetComponent<SnakeBodyCreator>();
        snakeHead = creator.GetParts(0);

        expManager = GetComponent<ExpManager>();
        expManager.OnLevelUp.AddListener(OnLevelUp);
    }

    public void SetColor(Color color)
    {
        creator.SetColor(color);
    }

    public void OnCollision(Collider2D collider)
    {
        GameObject gameObject = collider.gameObject;

        if (gameObject.CompareTag("Feed"))
        {
            float exp = gameObject.GetComponent<Feed>().Exp;
            expManager.AddExp(exp);

            Destroy(gameObject);
        }
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up!!");

        creator.AppendBody();
    }
}
