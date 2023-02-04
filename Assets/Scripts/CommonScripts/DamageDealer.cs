using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageValue;
    [SerializeField] bool isTrap;
    public int GetDamageValue()
    {
        return damageValue;
    }

    public bool GetIsTrap()
    {
        return isTrap;
    }

    public void Hit()
    {
        if (!isTrap)
        {
            Destroy(gameObject);
        }
    }
}
