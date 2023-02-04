using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public event System.Action OnSpot;

    public Light spotLight;
    [SerializeField] float viewDistance;
    public float timeToSpot = .5f;
    float playerVisibleTimer;
    float viewAngle;

    Transform playerPos;
    public LayerMask viewMask;
    Color defaultColor;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        viewAngle = spotLight.spotAngle;
        defaultColor = spotLight.color;
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            spotLight.color = Color.red;
            playerVisibleTimer += Time.deltaTime;
            transform.LookAt(playerPos);
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
            spotLight.color = defaultColor;
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpot);
        spotLight.color = Color.Lerp(defaultColor, Color.red, playerVisibleTimer / timeToSpot);

        if (playerVisibleTimer >= timeToSpot)
        {
            print("ahmet");
            if (OnSpot != null)
            {
                //OnSpot();
            }
        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, playerPos.position) < viewDistance)
        {
            Vector3 direction = (playerPos.position - transform.position).normalized;
            float angleBetween = Vector3.Angle(transform.forward, direction);
            if (angleBetween < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, playerPos.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * viewDistance);
    }
}
