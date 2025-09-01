using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject SpawnManager;
    private SpawningController SpawnController;
    public ScoreManager ScoreManager;
    
    public Vector2 WindChangeIntervalRange = new Vector2(15, 30);
    
    void Start()
    {
        SpawnController = SpawnManager.GetComponent<SpawningController>();
    }

    public void BeginGame()
    {
        SpawnController.BeginSpawning();
        ScoreManager.ActivateUI();
    }

    private IEnumerator WindChangeCoroutine()
    {
        bool WillHappen = RandomBool(0.35f);
        if (!WillHappen) yield return null;
        
        float NewTime = Random.Range(WindChangeIntervalRange.x, WindChangeIntervalRange.y);
        
        yield return new WaitForSeconds(NewTime);
        
        // Do change direction stuff
        
    }
    
    public static bool RandomBool(float ChanceToTrue = 0.5f)
   { 
       return Random.value < ChanceToTrue;
   }
}
