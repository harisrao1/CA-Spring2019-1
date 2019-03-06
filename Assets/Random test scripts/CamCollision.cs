using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollision : MonoBehaviour
{
    public float minDistance = 1;
    public float maxDistance = 4;
    public float smooth = 10;
    Vector3 MannyDirection;
    public Vector3 MannyDirectionAdjust;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        MannyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3  desiredCamPos = transform.parent.TransformPoint(MannyDirection * maxDistance);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position,desiredCamPos,out hit))
        {
            distance = Mathf.Clamp ((hit.distance*0.75f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, MannyDirection * distance, Time.deltaTime * smooth);
    }
}
