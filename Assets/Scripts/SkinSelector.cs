using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField]
    private Snake snake;

    [SerializeField]
    private Color SelectedSkin;
    private int SelectedIndex = 0;

    private void SetSkin()
    {
        SelectedSkin = PastelColor.All[SelectedIndex];
        snake.SetSkin(SelectedSkin);
    }

    public void PrevSkin()
    {
        --SelectedIndex;

        if (SelectedIndex < 0)
        {
            SelectedIndex = PastelColor.All.Length - 1;
        }

        SetSkin();
    }

    public void NextSkin()
    {
        ++SelectedIndex;

        if (SelectedIndex >= PastelColor.All.Length)
        {
            SelectedIndex = 0;
        }

        SetSkin();
    }

    public void Save()
    {
        Scene.SkinToLogin(SelectedSkin);
    }
}
