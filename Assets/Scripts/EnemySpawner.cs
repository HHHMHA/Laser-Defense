using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<WaveConfig> waveConfigurations;
    private int startingWaveIndex = 0;

    private void Start() {
        var currentWave = waveConfigurations[startingWaveIndex];
        StartCoroutine( SpawnAllEnemiesInWave( currentWave ) );
    }

    private IEnumerator SpawnAllEnemiesInWave( WaveConfig waveConfig ) {
        var enemyPrefab = waveConfig.EnemeyPrefab;

        for ( int enemyNumber = 0; enemyNumber < waveConfig.NumberOfEnemies; ++enemyNumber ) {
            var currentEnemy = Instantiate( enemyPrefab, waveConfig.GetWaypoints()[0].position, Quaternion.identity ) as GameObject;
            var currentEnemyPathing = currentEnemy.GetComponent<EnemyPathing>();
            currentEnemyPathing.WaveConfig = waveConfig;
            yield return new WaitForSeconds( waveConfig.TimeBetweenSpawnsSeconds + UnityEngine.Random.Range( -waveConfig.SpawnRandomFactorSeconds, waveConfig.SpawnRandomFactorSeconds) );
        }
    }
}
