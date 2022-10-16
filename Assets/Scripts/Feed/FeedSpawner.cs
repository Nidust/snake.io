using System.Collections;
using UnityEngine;

public class FeedSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject FeedPrefab;

    [SerializeField]
    private float Radius = 15;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 bundlePos = new Vector3(Random.Range(-Radius, Radius), Random.Range(-Radius, Radius), 0f);
            SpawnFeedBundle(bundlePos, 1f);

            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }

    private void SpawnFeedBundle(Vector3 center, float radius, int count = 5)
    {
        int spawnCount = Random.Range(count / 2, count);

        for (int index = 0; index < spawnCount; index++)
        {
            Vector3 spawnPos = center + new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0f);

            SpawnFeed(spawnPos);
        }
    }

    private void SpawnFeed(Vector3 position)
    {
        GameObject feed = Instantiate(FeedPrefab, position, Quaternion.identity, transform);
        SpriteRenderer sprite = feed.GetComponent<SpriteRenderer>();
        sprite.color = PastelColor.Random();
    }
}
