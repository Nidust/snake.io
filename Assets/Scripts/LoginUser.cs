using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUser : MonoBehaviour
{
    public static LoginUser instance;
    public string username;
    public Color skin;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public void Login(TextMeshProUGUI username)
    {
        this.username = username.text.ToUpper();

        SceneManager.LoadScene("GameScene");
    }

    public void LoadSkinScene()
    {
        SceneManager.LoadScene("SkinScene");
    }

    public void SetSkin(Color color)
    {
        skin = color;
    }
}
