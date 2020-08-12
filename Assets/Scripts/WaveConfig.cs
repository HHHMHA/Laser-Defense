using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Configuration")]
public class WaveConfig : ScriptableObject {
    [SerializeField] GameObject enemeyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawnsSeconds = 0.5f;
    [SerializeField] float spawnRandomFactorSeconds = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject EnemeyPrefab { get => enemeyPrefab; set => enemeyPrefab = value; }
    public GameObject PathPrefab { get => pathPrefab; set => pathPrefab = value; }
    public float TimeBetweenSpawnsSeconds { get => timeBetweenSpawnsSeconds; set => timeBetweenSpawnsSeconds = value; }
    public float SpawnRandomFactorSeconds { get => spawnRandomFactorSeconds; set => spawnRandomFactorSeconds = value; }
    public int NumberOfEnemies { get => numberOfEnemies; set => numberOfEnemies = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    public List<Transform> GetWaypoints() {
        var waveWayPoints = new List<Transform>();

        foreach ( Transform child in pathPrefab.transform )
            waveWayPoints.Add( child );

        return waveWayPoints;
    }
}
 