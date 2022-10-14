using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUser : MonoBehaviour
{
    public static LoginUser instance;
    public string username;

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
}
