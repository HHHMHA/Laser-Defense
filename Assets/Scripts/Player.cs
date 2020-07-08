using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float speed = 10f;
    [SerializeField][Tooltip("Porbably best to keep it at half the scale of the player, in Units")]
    private float playerOffsetFromScreen = 0.5f;
    [SerializeField] private Vector3 laserOffsetFromPlayer;
    [SerializeField] private float fireRate = 0.3f;

    private float xMin, xMax, yMin, yMax;
    private float nextFireTime = 0;

    private void Awake() {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        Vector3 bottomLeftWorldPoint = gameCamera.ViewportToWorldPoint( Vector3.zero );
        Vector3 topRightWorldPoint = gameCamera.ViewportToWorldPoint( Vector3.one );
        xMin = bottomLeftWorldPoint.x + playerOffsetFromScreen;
        xMax = topRightWorldPoint.x - playerOffsetFromScreen;
        yMin = bottomLeftWorldPoint.y + playerOffsetFromScreen;
        yMax = topRightWorldPoint.y - playerOffsetFromScreen;
    }

    void Update() {
        Move();
        TryFire();
    }

    private void TryFire() {
        if ( CanFire() )
            Instantiate( laserPrefab, transform.position + laserOffsetFromPlayer, Quaternion.identity );
    }

    private bool CanFire() {
        if ( !FireButtonPressed() )
            return false;

        float currentTime = Time.time;

        if ( currentTime < nextFireTime )
            return false;

        nextFireTime = currentTime + fireRate;
        return true;
    }

    private static bool FireButtonPressed() {
        return Input.GetAxis( "Fire1" ) > 0;
    }

    private void Move() {
        float horizontalInput = Input.GetAxis( "Horizontal" );
        float verticalInput = Input.GetAxis( "Vertical" );
        Vector3 movement = new Vector2( horizontalInput * speed, verticalInput * speed );
        Vector3 balancedDiagonalMovement = Vector2.ClampMagnitude( movement, speed );
        Vector3 frameIndependantMovement = balancedDiagonalMovement * Time.deltaTime;
        Vector3 newPosition = transform.position + frameIndependantMovement;
        Vector3 clampedPosition = new Vector3( Mathf.Clamp( newPosition.x, xMin, xMax ), Mathf.Clamp( newPosition.y, yMin, yMax ) );
        transform.position = clampedPosition;
    }
}
