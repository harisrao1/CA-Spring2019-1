using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavigationRootMotion : MonoBehaviour
{
    public float rotationSpeed = 80;
    public NavMeshAgent agent;
    public Camera cam;
    public float gravity = 100;
    float rotationY;
    public GameObject getDirector;
    private Director director;
    Ray ray;
    private Material[] skinMaterial;
    private Color[] orignalColor;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        director = getDirector.GetComponent<Director>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

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

        }
        else
        {
            
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
