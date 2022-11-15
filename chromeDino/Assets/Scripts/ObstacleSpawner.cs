using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    float currTime;
    [SerializeField]float maxTime = 2;
    [SerializeField] GameObject obstacle;

    private void Start()
    {
        currTime = 0;
    }


    void FixedUpdate()
    {
        if(currTime > maxTime)
        {
            ObstacleSpawn();
            currTime = 0;
        }
        else
        {
            currTime += Time.fixedDeltaTime;
        }
    }

    void ObstacleSpawn()
    {
        GameObject newObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);

        //to make obstacle spawner as parent
        newObstacle.transform.parent = this.gameObject.transform;

    }
}
