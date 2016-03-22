using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    Transform spawnpoint;
    public GameObject target;

    public int cooldown, relativeTargetCount;
    int currentCooldown;

    public int level, objectInLevel;

    // Use this for initialization
    void Start()
    {
        spawnpoint = GetComponent<Transform>();
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown == 0)
        {
            
            GameObject copy = Instantiate(target, transform.position, transform.rotation) as GameObject;
            TargetHealth targetScript = copy.gameObject.GetComponent<TargetHealth>();

            currentCooldown = cooldown;

            objectInLevel++;

            if (objectInLevel >= level * relativeTargetCount)
            {
                level++;
                objectInLevel = 0;
            }
        }

        if (currentCooldown > 0)
            currentCooldown--;
        
    }
}
