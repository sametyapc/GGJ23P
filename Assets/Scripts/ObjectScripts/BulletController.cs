using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
