using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField]
    private Snake snake;

    [SerializeField]
    private Color SelectedColor;
    private int SelectedIndex = 0;

    private void SetColor()
    {
        SelectedColor = PastelColor.All[SelectedIndex];
        snake.SetColor(SelectedColor);
    }

    public void SetPrevColor()
    {
        --SelectedIndex;

        if (SelectedIndex < 0)
        {
            SelectedIndex = PastelColor.All.Length - 1;
        }

        SetColor();
    }

    public void SetNextColor()
    {
        ++SelectedIndex;

        if (SelectedIndex >= PastelColor.All.Length)
        {
            SelectedIndex = 0;
        }

        SetColor();
    }

    public void Save()
    {
        LoginUser.instance.skin = SelectedColor;
    }
}
