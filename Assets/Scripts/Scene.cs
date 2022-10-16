using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static void LoginToGame(TextMeshProUGUI username)
    {
        LoginUser.Instance.UserName = username.text.ToUpper();

        SceneManager.LoadScene("GameScene");
    }

    public static void LoginToSkin()
    {
        SceneManager.LoadScene("SkinScene");
    }

    public static void SkinToLogin(Color skin)
    {
        LoginUser.Instance.Skin = skin;

        SceneManager.LoadScene("LoginScene");
    }
}
