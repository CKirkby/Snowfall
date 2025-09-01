using UnityEngine;

public class DestructionBoundry : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public SpawningController SpawnController;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) return;

        if (SpawnController)
        {
            SpawnController.DestroySnow(other.gameObject);
        }
        
        if (ScoreManager)
        {
            ScoreManager.AddScore(1);
        }
    }
}
