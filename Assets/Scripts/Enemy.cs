using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameObject laserPrefab;
    void Start() {
        StartCoroutine( Fire() );
    }

    private IEnumerator Fire() {
        while( true ) {
            GameObject laser = Instantiate( laserPrefab, transform.position, Quaternion.identity ); // TODO this will kill the enemy fix it
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.ReverseDirection = true;

            yield return new WaitForSeconds( 1 );
        }
    }
}
