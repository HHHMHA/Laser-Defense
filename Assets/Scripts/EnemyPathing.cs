using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField][Tooltip("List of waypoints that define an enemy path with thier positions")] private List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    private int wayPointIndex = 0;

    public int WayPointIndex { get => wayPointIndex; }

    public int IncrementWayPointIndex() => ++wayPointIndex;

    public void Start() {
        InitializePositionToFirstWaypoint();
    }

    private void InitializePositionToFirstWaypoint() {
        transform.position = waypoints[0].position;
    }

    private void Update() {
        if ( LastWayPointReached() ) {
            Destroy( gameObject );
            return;
        }

        Move();
    }

    private void Move() {
        Vector3 targetPosition = waypoints[wayPointIndex].position;
        float moveSpeedFrameIndependant = moveSpeed * Time.deltaTime;

        Vector3 newPosition = Vector2.MoveTowards( transform.position, targetPosition, moveSpeedFrameIndependant );
        transform.position = newPosition;

        if ( transform.position == targetPosition )
            IncrementWayPointIndex();
    }

    private bool LastWayPointReached() {
        return wayPointIndex >= waypoints.Count;
    }
}
