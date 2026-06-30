using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private bool spawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !spawned)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}