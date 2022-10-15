using UnityEngine;

public class FeedManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FeedPrefab;

    [SerializeField]
    private float Raidus = 15;

    [SerializeField]
    private int Count = 100;

    private void Start()
    {
        for (int index = 0; index < Count; index++)
        {
            Vector3 position = new Vector3(Random.Range(-Raidus, Raidus), Random.Range(-Raidus, Raidus), 0f);
            GameObject feed = Instantiate(FeedPrefab, position, Quaternion.identity, transform);
            SpriteRenderer sprite = feed.GetComponent<SpriteRenderer>();
            sprite.color = Random.ColorHSV();
        }
    }
}
