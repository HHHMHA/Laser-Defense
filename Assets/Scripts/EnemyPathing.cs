using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int wayPointIndex = 0;

    public int WayPointIndex { get => wayPointIndex; }
    public WaveConfig WaveConfig { get => waveConfig; set => waveConfig = value; }

    public int IncrementWayPointIndex() => ++wayPointIndex;

    public void Start() {
        waypoints = waveConfig.GetWaypoints();
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
        float moveSpeedFrameIndependent = waveConfig.MoveSpeed * Time.deltaTime;

        Vector3 newPosition = Vector2.MoveTowards( transform.position, targetPosition, moveSpeedFrameIndependent );
        transform.position = newPosition;

        if ( transform.position == targetPosition )
            IncrementWayPointIndex();
    }

    private bool LastWayPointReached() {
        return wayPointIndex >= waypoints.Count;
    }
}
