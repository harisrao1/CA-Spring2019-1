using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicObstacleMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshObstacle obstacle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* 
         * was thinking of how I could see if any agents 
         * x position is within like, 10 units of this obstacle's position
         * but there are probably other ways to do this
      
        if (agent.transform.position.x <= Mathf.Abs())
        {

        }
        */
    }
}
