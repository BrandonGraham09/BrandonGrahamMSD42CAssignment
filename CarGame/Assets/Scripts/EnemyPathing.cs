﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float enemieMoveSpeed = 2f;

    //Saves the waypoint in which we want to go 
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // set the start postition of Enemy to the 1st waypoint
        transform.position = waypoints[waypointIndex].transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var enemyMovement = enemieMoveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}