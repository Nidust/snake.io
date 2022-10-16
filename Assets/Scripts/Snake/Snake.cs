using UnityEngine;

[RequireComponent(typeof(ExpManager))]
public class Snake : MonoBehaviour
{
    public Color Skin;
    private SnakeBody SnakeBody;
    private ExpManager ExpManager;
    
    private void Start()
    {
        SnakeBody = GetComponentInChildren<SnakeBody>();
        ExpManager = GetComponent<ExpManager>();
        ExpManager.OnLevelUp.AddListener(OnLevelUp);

        SetSkin(LoginUser.Instance.Skin);
    }

    public void SetSkin(Color skin)
    {
        Skin = skin;
        GetComponent<SpriteRenderer>().color = skin;

        SnakeBody.SetSkin(skin);
    }

    public void EatFeed(Feed feed)
    {
        float exp = feed.Exp;
        ExpManager.AddExp(exp);

        Destroy(feed.gameObject);
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up!!");
        SnakeBody.Append();
    }
}
