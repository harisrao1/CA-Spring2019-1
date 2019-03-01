using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicObstacleMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshObstacle obstacle;
    private int count;
    private float initialHeight;
    bool open;

    void Start()
    {
        open = false;
        count = 0;
        initialHeight = obstacle.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(open == true && obstacle.transform.position.y <= initialHeight + 5)
        {
            obstacle.transform.Translate(new Vector3(0f, 3f, 0f) * Time.deltaTime);
        }
        else if(count == 0 && open == false && obstacle.transform.position.y >= initialHeight)
        {
            obstacle.transform.Translate(new Vector3(0f, -3f, 0f) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "agents" || other.gameObject.transform.parent.tag == "nazguls")
        {
            open = true;
            ++count;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "agents" || other.gameObject.transform.parent.tag == "nazguls")
        {
            open = false;
            --count;
        }
    }
}
