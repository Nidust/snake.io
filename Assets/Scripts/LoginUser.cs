using UnityEngine;

public class LoginUser : MonoBehaviour
{
    public static LoginUser Instance;
    public string UserName;
    public Color Skin = Color.white;

    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
