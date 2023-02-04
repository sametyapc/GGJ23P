using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletExitPoint;
    [SerializeField] float fireRate;
    bool canShoot;
    [SerializeField] bool isPlayer;
    [SerializeField] float bulletSpeed;
    [SerializeField]bool inBattle;

    private void Start()
    {
        canShoot = true;
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed && canShoot)
        {
            if (inBattle)
            {
                StartCoroutine("FireRoutine");

            }
        }
    }

    IEnumerator FireRoutine()
    {
        canShoot= false;
        var newBullet = Instantiate(bullet,bulletExitPoint.position,Quaternion.Euler(0,90,0));
        if (transform.localScale.x < 0)
        {
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0,0, -bulletSpeed);

        }
        else
        {
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
        }
        newBullet.layer = isPlayer ? LayerMask.NameToLayer("PlayerBullet"): LayerMask.NameToLayer("EnemyBullet");
        yield return new WaitForSeconds(fireRate);
        canShoot= true;
    }

    public void InBattleStatus(bool status)
    {
        inBattle= status;
    }

}
