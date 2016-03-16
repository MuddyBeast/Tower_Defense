using UnityEngine;
using System.Collections.Generic;

public class TargetHealth : MonoBehaviour
{
    public int level;
    public int health;
    List<Turret> turretsInRange = new List<Turret>();

    // Use this for initialization
    void Start()
    {
        health *= level;
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
