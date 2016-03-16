using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public int lifeTime;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
            transform.LookAt(target.transform);
        else
            Destroy(gameObject, lifeTime);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Vision"))
            Destroy(gameObject);
    }
}
