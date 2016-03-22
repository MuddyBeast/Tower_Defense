using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TargetHealth : MonoBehaviour
{
    float health;
    public float startHealth;
    public float lifeTime;
    List<Turret> turretsInRange = new List<Turret>();

    public Image healthBar;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            foreach (Turret turret in turretsInRange)
            {
                turret.targets.Remove(gameObject);
                turret.distances.RemoveAt(0);
            }
            Destroy(gameObject);
        }

        healthBar.fillAmount = health / startHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (health > other.gameObject.GetComponent<Projectile>().damage)
            {
                health -= other.gameObject.GetComponent<Projectile>().damage;
            }
            else
                health = 0;
        }
        if (other.CompareTag("Vision"))
        {
            turretsInRange.Add(other.gameObject.GetComponent<Turret>());
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vision"))
            turretsInRange.Remove(other.gameObject.GetComponent<Turret>());
    }
}
