using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbStairScripts : MonoBehaviour
{
    [SerializeField] GameObject stepRayLower;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 0.1f;

    private Rigidbody _myRigid;

    private void Awake()
    {
        stepRayUpper.transform.position = new Vector3
        (stepRayUpper.transform.position.x, stepHeight,
        stepRayUpper.transform.position.z);
    }

    private void Start()
    {
        _myRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        StepClimb();    
    }

    private void StepClimb()
    {
        RaycastHit hitLower;
        Debug.DrawLine(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        Debug.DrawLine(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(stepRayLower.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitUpper, 0.2f))
            {
                _myRigid.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }

        RaycastHit hitLower45;
        Debug.DrawLine(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        Debug.DrawLine(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(stepRayLower.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitLower45, 0.1f))
        {
            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitUpper45, 0.2f))
            {
                _myRigid.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }

        RaycastHit hitLowerMinus45;
        Debug.DrawLine(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
        Debug.DrawLine(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), Color.blue);
        if (Physics.Raycast(stepRayLower.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitLowerMinus45, 0.1f))
        {
            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, 
            transform.TransformDirection(Vector3.forward),
            out hitUpperMinus45, 0.2f))
            {
                _myRigid.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
    }
}
