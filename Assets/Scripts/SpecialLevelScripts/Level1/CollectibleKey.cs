using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleKey : MonoBehaviour
{
    bool isCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            FindObjectOfType<LevelControllerFirst>().ExecuteEvent();
            isCollected= true;
            gameObject.SetActive(false);
        }
    }

    
}
