using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] bool reverseDirection = false;
    [SerializeField] Sprite laserSprite;

    public bool ReverseDirection { get => reverseDirection; set => reverseDirection = value; }
    public Sprite LaserSprite { get => laserSprite; set => laserSprite = value; }

    private void Awake() {
        if ( laserSprite != null )
            SetLaserSpriteOnGameObject();
    }

    private void SetLaserSpriteOnGameObject() {
        GetComponent<SpriteRenderer>().sprite = laserSprite;
    }

    void Update() {
        Vector3 movement = reverseDirection ? Vector3.down * speed : Vector3.up * speed;
        Vector3 frameIndependantMovement = movement * Time.deltaTime;
        transform.Translate( frameIndependantMovement );
    }

    private void OnCollisionEnter2D( Collision2D collision ) {
        Destroy( gameObject );
    }
}
