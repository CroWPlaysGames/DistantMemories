using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Walking_Ghost : MonoBehaviour
{
    public Transform pathHolder;
    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;

    public Light spotlight;
    public float viewDistance;
    float viewAngle;
    Transform player;
    public LayerMask viewmask;
    Color spotlightColor;
    bool reset = false;
    AudioSource caughtSound;
    Vector3[] waypoints;

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach(Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .1f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    void Start()
    {
        spotlightColor = spotlight.color;
        viewAngle = spotlight.spotAngle;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        waypoints = new Vector3[pathHolder.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }

        StartCoroutine(FollowPath(waypoints));
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardandPlayer = Vector3.Angle(transform.forward, dirToPlayer);

            if (angleBetweenGuardandPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewmask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    IEnumerator Caught(Vector3 lookTarget)
    {
        FirstPersonController player = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, 4 * turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
        }

        caughtSound = GetComponent<AudioSource>();
        caughtSound.Play(0);
        player.enabled = false;
        yield return new WaitForSeconds(2.5f);
        player.transform.position = new Vector3(15.84f, 14.17f, -21.51f);
        Vector3 forward = new Vector3(0, 180, 0);
        player.transform.rotation = Quaternion.LookRotation(forward);
        player.enabled = true;
        player.m_WalkSpeed = player.crouch_speed * 2;

        reset = false;

        StartCoroutine(FollowPath(waypoints));
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (!reset)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];

                yield return new WaitForSeconds(waitTime);

                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }

            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            spotlight.color = Color.red;

            if (!reset)
            {
                reset = true;

                StopAllCoroutines();

                StartCoroutine(Caught(player.transform.position));
            }
        }

        else
        {
            spotlight.color = spotlightColor;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<FirstPersonController>().crouching && !reset &&
                (Input.GetKey(KeyCode.W) || 
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.LeftShift)))
            {
                spotlight.color = Color.red;

                reset = true;

                StopAllCoroutines();

                StartCoroutine(Caught(player.transform.position));
            }

            else
            {
                spotlight.color = spotlightColor;
            }
        }
    }
}
