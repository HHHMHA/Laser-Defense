using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField][Tooltip("Porbably best to keep it at half the scale of the player, in Units")]
    private float offsetFromScreen = 0.5f;
    private float xMin, xMax, yMin, yMax;

    private void Awake() {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        Vector3 bottomLeftWorldPoint = gameCamera.ViewportToWorldPoint( Vector3.zero );
        Vector3 topRightWorldPoint = gameCamera.ViewportToWorldPoint( Vector3.one );
        xMin = bottomLeftWorldPoint.x + offsetFromScreen;
        xMax = topRightWorldPoint.x - offsetFromScreen;
        yMin = bottomLeftWorldPoint.y + offsetFromScreen;
        yMax = topRightWorldPoint.y - offsetFromScreen;
    }

    void Update() {
        Move();
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
