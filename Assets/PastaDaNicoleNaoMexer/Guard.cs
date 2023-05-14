using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform path;
    public float waittime = 0.3f;
    public float speed = 5f;
    public float turnSpeed = 90f;

    public Light spotLight;
    public float ViewDistance;
    float viewAngle;

    public LayerMask viewMask;

    public Collider detector;

    Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3[] waypoints = new Vector3[path.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = path.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
            
        }
        StartCoroutine(FollowPath(waypoints));
    }

    private void Update()
    {
    //     if(CanSeePlayer())
    //     {
    //         spotLight.color = Color.red;
    //         Debug.Log("Vendo o player");
        // }
    }

    // bool CanSeePlayer()
    // {
    //     // if(Vector3.Distance(transform.position,player.position) < ViewDistance)
    //     // {
    //     //     Vector3 dirToPlayer = (player.position - transform.position).normalized;
    //     //     float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
    //     //     if(angleBetweenGuardAndPlayer < viewAngle /2f)
    //     //     {
    //     //          if(!Physics.Linecast(transform.position, player.position, viewMask))
    //     //         {
    //     //             return true;
    //     //         }
    //     //     }        
    //     // }
    //     // return false;
    //     if(detector.isTrigger)
    //     {
            
    //     }

    // }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        //transform.LookAt(targetWaypoint);
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            transform.LookAt(new Vector3(targetWaypoint.x, transform.position.y, targetWaypoint.z));
            if(transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waittime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)> 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

   private void OnDrawGizmos()
   {
       Vector3 startPos = path.GetChild(0).position;
       Vector3 previousPos = startPos;

       foreach (Transform waypoint in path)
       {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPos, waypoint.position);
            previousPos = waypoint.position;
       }
       Gizmos.DrawLine(previousPos, startPos);
   }
}
