using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicObstacleMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshObstacle obstacle;
    private int count;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Map" && other.gameObject.transform.parent.tag != "Obstacles")
        {
            Debug.Log(count + "onEnterBefore");
            ++count;
            Debug.Log(count + "onEnterAfter");
            while (obstacle.transform.position.y <= 7.5)
            {
                obstacle.transform.Translate(Vector3.up);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Map" && other.gameObject.transform.parent.tag != "Obstacles")
        {
            Debug.Log(count + "onExitBefore");
            --count;
            Debug.Log(count + "onExitAfter");
            while (count == 0 && obstacle.transform.position.y >= 3.5)
            {
                obstacle.transform.Translate(Vector3.down);
            }
        }
    }
}
