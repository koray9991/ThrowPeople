using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public GameObject target, me;
    public float x, y, z;
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if ((CharacterCollider.instance.leftObject == null || CharacterCollider.instance.rightObject == null) )
        {
            FindClosestEnemy();
            transform.localScale = new Vector3(x, y, z);

        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
    void FindClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Arrow");
        if (allEnemies.Length != 0)
        {
            foreach (GameObject currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - me.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceClosestEnemy)
                {
                    distanceClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                    target = closestEnemy.gameObject;
                    
                    
                    z = Vector3.Distance(me.transform.position, target.transform.position) / 30;
                    if (z > 0.4f)
                    {
                        z = 0.4f;
                    }
                    if (z < 0.12f)
                    {
                        z = 0.12f;
                    }
                   
                }
            }

        }
        else
        {
            x = 0;y = 0;z = 0;
        }
        transform.LookAt(target.transform);


    }
}
