using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {   
        waveConfig = enemySpawner.GetCurrentWave();
        //runs the GetWaypoints function in the WaveConfigSO script, which gets the waypoints as a list of Transform integers 
        waypoints = waveConfig.GetWaypoints();
        //then moves the enemy onto whichever waypoint the waypointIndex selects
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            //the MoveTowards is a inbuilt vector2 function that takes 3 variables, the existing position, the position the target wants to move to and the time it takes to do so
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
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
