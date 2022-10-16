using UnityEngine;

public class Feed : MonoBehaviour
{
    public float Exp;

    [SerializeField]
    private float EventSpeed;
    private Vector3 targetScale;

    private void Awake()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        SpawnEvent();
    }

    private void SpawnEvent()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, EventSpeed * Time.deltaTime);
    }
}
