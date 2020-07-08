using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    void Update() {
        Vector3 movement = Vector3.up * speed;
        Vector3 frameIndependantMovement = movement * Time.deltaTime;
        transform.Translate( frameIndependantMovement );
    }

    private void OnCollisionEnter2D( Collision2D collision ) {
        Destroy( gameObject );
    }
}
