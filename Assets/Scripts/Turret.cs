using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    public float rotationSpeed;
    List<GameObject> targets = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var targetRotation = Quaternion.LookRotation(targets[0].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    float Sort()
    {
        return 0f;
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
