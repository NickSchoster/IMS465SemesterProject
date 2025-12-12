using UnityEngine;

public class EnemySPawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyPrefab;   
    public float spawnInterval = 2f;
    public Transform spawnPoint;
    public float maxEnemyCount = 0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (maxEnemyCount <= 5000)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            maxEnemyCount++;
        }
    }
}
