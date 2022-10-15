using UnityEngine;
using UnityEngine.Events;

public class ExpManager : MonoBehaviour
{
    public UnityEvent OnLevelUp = new UnityEvent();
    private float exp = 0f;

    public void AddExp(float value)
    {
        Debug.Log($"AddExp: {exp} + {value}");

        exp += value;
        if (exp >= 100f)
        {
            OnLevelUp.Invoke();
            exp = 0f;
        }
    }
}
