using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NazgulDetect : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshAgent agent1;
    public NavMeshAgent agent2;
    public NavMeshAgent agent3;
    public NavMeshAgent agent4;
    public NavMeshAgent agent5;

    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    
    public NavMeshAgent nazgul;
    public GameObject getDirector;
    private Director director;

    // Start is called before the first frame update
    void Start()
    {
        director = getDirector.GetComponent<Director>();

        Vector3 floorpos0 = cube0.transform.position;
        Vector3 floorpos1 = cube1.transform.position;
        Vector3 floorpos2 = cube2.transform.position;
        Vector3 floorpos3 = cube3.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == agent)
        {
            Vector3 pos = agent.destination;
            
        }
    }
}
