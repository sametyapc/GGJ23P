using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelControllerFirst : MonoBehaviour
{
    // EnemySpawner eklenecek, event in içine koyulacak, enemyler oyuncu ile ayný health ve shooter scriptini kullanacak

    [SerializeField] GameObject cornersFirst,cornersSecond;

    public event System.Action OnKeyCollected;

    bool isKeyCollected;

    private void Start()
    {
        OnKeyCollected += ActivateTurnCorners;
        OnKeyCollected += CollectKey;
    }
    void ActivateTurnCorners()
    {
        cornersFirst.SetActive(false);
        cornersSecond.SetActive(true);
        OnKeyCollected-= ActivateTurnCorners;
    }

    void CollectKey()
    {
        isKeyCollected= true;
        OnKeyCollected-= CollectKey;
    }

    public bool GetKeyStatus()
    {
        return isKeyCollected;
    }

    public void ExecuteEvent()
    {
        OnKeyCollected();
    }
}
