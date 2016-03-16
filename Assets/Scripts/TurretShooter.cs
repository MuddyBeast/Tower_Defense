using UnityEngine;
using System.Collections;

public class TurretShooter : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject shot;

    Projectile shotScript;
    Turret turret;

    int currentCooldown;

    // Use this for initialization
    void Start()
    {
        turret = GetComponentInParent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turret.shoot)
        {
            if (currentCooldown == 0)
            {
                GameObject turretShot = Instantiate(shot, bulletSpawn.position, turret.transform.rotation) as GameObject;
                shotScript = turretShot.gameObject.GetComponent<Projectile>();
                shotScript.speed = turret.shotSpeed;
                shotScript.damage = turret.shotDamage;
                shotScript.target = turret.targets[0];

                currentCooldown = turret.shotCooldown;
            }
        }

        if(currentCooldown > 0)
            currentCooldown--;
    }
}
