using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    GameObject player;
    float speed = 4;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        DestroyObstacle();
        transform.position -= new Vector3(speed*Time.deltaTime, 0, 0); 
    }

    void DestroyObstacle()
    {
        if(transform.position.x < player.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
