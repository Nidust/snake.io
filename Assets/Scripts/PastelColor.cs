using UnityEngine;

public static class PastelColor
{
    #region Variables
    public static Color Red
    {
        get
        {
            Color result;

            if (ColorUtility.TryParseHtmlString("#ff6b6b", out result))
            {
                return result;
            }

            return Color.white;
        }
    }

    public static Color Green
    {
        get
        {
            Color result;

            if (ColorUtility.TryParseHtmlString("#1dd1a1", out result))
            {
                return result;
            }

            return Color.white;
        }
    }

    public static Color Blue
    {
        get
        {
            Color result;

            if (ColorUtility.TryParseHtmlString("#48dbfb", out result))
            {
                return result;
            }

            return Color.white;
        }
    }

    public static Color Yellow
    {
        get
        {
            Color result;

            if (ColorUtility.TryParseHtmlString("#feca57", out result))
            {
                return result;
            }

            return Color.white;
        }
    }

    public static Color Pink
    {
        get
        {
            Color result;

            if (ColorUtility.TryParseHtmlString("#ff9ff3", out result))
            {
                return result;
            }

            return Color.white;
        }
    }
    #endregion

    #region Method
    public static Color[] All = { Color.white, Red, Green, Blue, Yellow, Pink };
    public static Color Random()
    {
        return All[UnityEngine.Random.Range(0, All.Length)];
    }
    #endregion
}
