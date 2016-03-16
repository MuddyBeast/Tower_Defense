using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    public float rotationSpeed;
    public List<GameObject> targets = new List<GameObject>();
    public List<float> distances = new List<float>();
    public bool shoot;
    public int shotCooldown, shotDamage;
    public float shotSpeed;
    public bool stayOnTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                distances[i] = Vector3.Distance(transform.position, targets[i].transform.position);
            }

            if (targets.Count > 1)
            {
                if (!stayOnTarget)
                    Sort();
            }


            var targetRotation = Quaternion.LookRotation(targets[0].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Vector3 length = targets[0].transform.position - transform.position;
            Vector3 direction = transform.forward;


            if (Vector3.Angle(length, direction) < 10)
                shoot = true;
            else
                shoot = false;
        }

        else if (targets.Count == 0 && shoot)
            shoot = false;
    }

    void Sort()
    {
        int unsortedNumbers;

        do
        {
            int previousNumberPosition = 0;
            unsortedNumbers = 0;

            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < distances[previousNumberPosition])
                {
                    GameObject targetChange = targets[i];
                    float distanceChange = distances[i];
                    distances[i] = distances[previousNumberPosition];
                    distances[previousNumberPosition] = distanceChange;
                    targets[i] = targets[previousNumberPosition];
                    targets[previousNumberPosition] = targetChange;
                    unsortedNumbers++;
                }

                previousNumberPosition = i;
            }

        } while (unsortedNumbers != 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targets.Add(other.gameObject);
            distances.Add(0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targets.Remove(other.gameObject);
            distances.RemoveAt(0);
            Sort();
        }

    }
}
