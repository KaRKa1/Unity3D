using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 movDirection = target.position - transform.position;
        transform.Translate(movDirection.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(wavePointIndex >= Waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
}
