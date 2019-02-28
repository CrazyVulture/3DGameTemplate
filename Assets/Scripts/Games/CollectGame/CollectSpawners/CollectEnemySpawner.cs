
using UnityEngine;

public class CollectEnemySpawner : BaseSpawner
{
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }
    
    void Spawn()
    {
        if (PlayerController.GetPlayerStatus()==PlayerStatus.DEAD || PlayerController.GetPlayerStatus()==PlayerStatus.WIN)
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        spawnPosition = spawnPoints[spawnPointIndex].position;
        spawnRotation = spawnPoints[spawnPointIndex].rotation;
        var enemy = spawnObjects[Random.Range(0, spawnObjects.Length)];
        Instantiate(enemy, spawnPosition, spawnRotation);
    }
}
