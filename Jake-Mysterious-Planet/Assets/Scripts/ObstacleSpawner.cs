using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;

    private void Start()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length - 1);
        Instantiate(obstaclePrefab, spawnPoints[randomIndex]);
    }

}