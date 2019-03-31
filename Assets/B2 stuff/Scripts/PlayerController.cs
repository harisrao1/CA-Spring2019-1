using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    public GameObject getDirector;
    private Director director;

    public ThirdPersonCharacter character;
    private Animator animator;

    private bool onoffmesh;

    private Material[] skinMaterial;
    private Color[] orignalColor;

    private float runC;

    private float runspeed;
    private float walkspeed;

    void Start ()
    {
        agent.updateRotation = false;
        director = getDirector.GetComponent<Director>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        if (agent.isOnOffMeshLink)
        {
            onoffmesh = true;
            animator.SetInteger("Jump", 1);
        }
        else
        {
            animator.SetInteger("Jump", 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform.gameObject.tag == "agent1")
                {
                    director.selected = hit.collider.tag;
                }
                else if (director.selected == agent.tag)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        skinMaterial = new Material[renderers.Length];
        orignalColor = new Color[renderers.Length];

        if (director.selected == agent.tag)
        {

            for (int i = 0; i < renderers.Length; i++)
            {
                skinMaterial[i] = renderers[i].material;

                orignalColor[i] = skinMaterial[i].color;
            }

            skinMaterial[2].color = Color.red;
            skinMaterial[1].color = Color.red;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                runC++;
            }
            Debug.Log("Agent speed: " + agent.speed);
            if (runC % 2 == 0)
            {
                skinMaterial[2].color = Color.red;
                skinMaterial[1].color = Color.red;
                agent.speed = 1.25f;
                animator.speed = 0.34f;
            }
            else
            {
                skinMaterial[2].color = Color.blue;
                skinMaterial[1].color = Color.blue;
                agent.speed = 4f;
                animator.speed = 0.84f;
            }

        }
        else
        {
            runC = 2;
            for (int i = 0; i < renderers.Length; i++)
            {
                skinMaterial[i] = renderers[i].material;

                orignalColor[i] = skinMaterial[i].color;
            }
            skinMaterial[2].color = Color.white;
            skinMaterial[1].color = Color.white;
        }


    }
}
