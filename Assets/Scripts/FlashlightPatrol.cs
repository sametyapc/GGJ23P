using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashlightPatrol : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float waitingTime;
    [SerializeField] float turningSpeed;

    private void Start()
    {
        Vector3[] points = new Vector3 [path.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = path.GetChild(i).position;
        }
        StartCoroutine(LookAtPointsRoutine(points));
    }

    IEnumerator LookAtPointsRoutine(Vector3[] waypoints)
    {
        while (true)
        {
            int pointIndex = Random.Range(0, waypoints.Length);
            Vector3 target = waypoints[pointIndex];
            Vector3 direction = (target - transform.position);
            Quaternion toRotate = Quaternion.LookRotation(direction);
            transform.DORotateQuaternion(toRotate, turningSpeed * Time.deltaTime);
            yield return new WaitForSeconds(waitingTime);
            yield return null;
        }
    
    }
    private void OnDrawGizmos()
    {
        Vector3 startPos = path.GetChild(0).position;
        Vector3 prevPos = startPos;

        foreach (Transform waypoint in path)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(prevPos, waypoint.position);
            prevPos = waypoint.position;
        }
        Gizmos.DrawLine(prevPos, startPos);
    }
}
