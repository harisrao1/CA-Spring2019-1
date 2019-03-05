using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveScriptforPart3 : MonoBehaviour
{
    public Transform dest;
    NavMeshAgent agent;
    private Animator animator;
    public float walkspeed;
    private float dynamicwalkspeed;
    private bool isStopped;
    [Range(-15, 75)] [SerializeField] private float XPosition = 60;
    [Range(-15, 75)] [SerializeField] private float ZPosition = 60;

    void Start()
    {
       // dest = new Vector3(XPosition, 0, ZPosition);
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(dest.position);
        animator = this.GetComponent<Animator>();
        dynamicwalkspeed = walkspeed;
        isStopped = false;
    }

    
    void Update()
    {
        if (isStopped)
        {
            animator.SetInteger("walk", 0);
            agent.speed = 0;
           // agent.angularSpeed = 0;
        }
        
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            
            agent.speed = dynamicwalkspeed;
            if (dynamicwalkspeed > 0 )
            {
                animator.SetInteger("walk", 1);
                
            }
            else
            {
                dynamicwalkspeed = 0;
                animator.SetInteger("walk", 0);
            }
        }
        else
        {
            animator.SetInteger("walk", 0);
        
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "agent1" && (other.isTrigger==false))
        {
            dynamicwalkspeed = 0;
            Debug.Log("touching");
        }
        if (other.GetComponent<NavMeshAgent>().velocity == Vector3.zero)
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }
        
     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "agent1")
        {
            dynamicwalkspeed = walkspeed;
           
        }
    }
}
