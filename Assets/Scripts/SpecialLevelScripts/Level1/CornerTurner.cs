using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTurner : MonoBehaviour
{
    [SerializeField] float rotateValue;
    [SerializeField] bool goBattle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.rotation = Quaternion.AngleAxis(rotateValue,transform.up);
            other.GetComponent<ShooterController>().InBattleStatus(goBattle);
            gameObject.SetActive(false);
        }
    }
}
