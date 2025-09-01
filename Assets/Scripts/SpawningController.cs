using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawningController : MonoBehaviour
{
    public GameObject SpawnClass;
    public Vector2 SpawnIntervalRange = new (0.5f, 1.5f);
    public GameObject[] SpawnPoints;

    // A list of the currently spawned snowflakes for mass use
    private List<GameObject> SpawnedSnow = new();
    
    public void BeginSpawning()
    {
        StartCoroutine(SpawnCoroutine());
    }
    
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            { 
                var SpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform;
                
                GameObject SpawnedSnowflake = Instantiate(SpawnClass,  SpawnPoint.position, Quaternion.identity);
                SpawnedSnow.Add(SpawnedSnowflake);
            }
            
            yield return new WaitForSeconds(Random.Range(SpawnIntervalRange.x, SpawnIntervalRange.y));
        }
        
        // ReSharper disable once IteratorNeverReturns
    }

    public void DestroySnow(GameObject SnowToDestroy)
    {
        if (!SnowToDestroy) return;
        
        if (SpawnedSnow.Contains(SnowToDestroy))
        {
            SpawnedSnow.Remove(SnowToDestroy);
        }

        Destroy(SnowToDestroy);
    }
}
