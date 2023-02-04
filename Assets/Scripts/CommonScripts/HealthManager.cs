using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth=1;
    [SerializeField] bool isPlayer;
    [SerializeField] bool isTrap;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            DecreaseHealth(damageDealer.GetDamageValue());
            if (!isPlayer)
            {
                damageDealer.Hit();
            }
            
        }
    }

    void DecreaseHealth(int damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
