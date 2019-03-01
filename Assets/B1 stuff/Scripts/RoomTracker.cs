using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomTracker : MonoBehaviour
{
    public Camera cam;
    public GameObject floor;
    public int count;
    public GameObject getDirector;
    private Director director;

    void Start()
    {
        director = getDirector.GetComponent<Director>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Safe Floor Min Count: " + director.safeFloorCount);
        if (count > director.safeFloorCount)
        {
            for (int i = 0; i < 3; i++)
            {
                if (director.list.Contains(floor))
                {
                    director.list.Remove(floor);
                    break;
                }
            }
            
        }
        else if (count <= director.safeFloorCount)
        {
            director.safeFloorCount = count;
            for (int i = 0; i < 3; i++)
            {
                if (director.list.Contains(floor))
                {
                    Debug.Log("Already in list");
                    break;
                }
                else if (!director.list.Contains(floor))
                {
                    Debug.Log("Adding to list");
                    director.list.Add(floor);
                    break;
                }
                else
                {
                    Debug.Log("How? " + floor.tag);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "nazguls")
        {
            ++count;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "nazguls")
        {
            --count;
        }
    }
}
