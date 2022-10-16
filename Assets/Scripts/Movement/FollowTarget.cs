using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject TargetObject;
    [SerializeField]
    private float FollowSpeed;
    [SerializeField]
    private bool Immediately = false;
    [SerializeField]
    private Vector2 Offset;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(TargetObject.transform.position.x, TargetObject.transform.position.y, transform.position.z);
        targetPosition.x += Offset.x;
        targetPosition.y += Offset.y;

        if (Immediately)
        {
            transform.position = targetPosition;
        }
        else
        {
            Vector3 newPosition = Vector3.Slerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
