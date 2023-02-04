using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeWindow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool keyStatus = FindObjectOfType<LevelControllerFirst>().GetKeyStatus();
            if (!keyStatus)
            {
                print("I think need to find key");
            }
            else
            {
                print("There we go!"); // Pencere açýlacak
            }
        }
    }
}
