using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RectArrow : MonoBehaviour
{
    public GameObject Target;
    public Transform me;
    RectTransform rt;
    float rotFloat;
    void Start()
    {
        rt = GetComponent<RectTransform>();
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
                    Target= closestEnemy.gameObject;
                    if(Vector3.Distance(Target.transform.position, me.transform.position) < 15 && (CharacterCollider.instance.leftObject == null || CharacterCollider.instance.rightObject == null))
                    {
                        GetComponent<Image>().enabled = true;
                        Arrow();
                    }
                    else
                    {
                        GetComponent<Image>().enabled = false;
                    }
                }
            }
           
        }



    }
    void Arrow()
    {
        // Get the position of the object in screen space
        Vector3 objScreenPos = Camera.main.WorldToScreenPoint(Target.transform.position);

        // Get the directional vector between your arrow and the object
        Vector3 dir = (objScreenPos - rt.position).normalized;

        // Calculate the angle 
        // We assume the default arrow position at 0° is "up"
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(dir, Vector3.up));

        // Use the cross product to determine if the angle is clockwise
        // or anticlockwise
        Vector3 cross = Vector3.Cross(dir, Vector3.up);
        angle = -Mathf.Sign(cross.z) * angle;

        // Update the rotation of your arrow
        rt.localEulerAngles = new Vector3(rt.localEulerAngles.x, rt.localEulerAngles.y, angle);

        
        if (rt.rotation.eulerAngles.z > 180)
        {
            rotFloat = rt.rotation.eulerAngles.z - 360;
        }
        else
        {
            rotFloat = rt.rotation.eulerAngles.z;
        }
       
        rt.localPosition = new Vector3(-rotFloat, rt.localPosition.y, rt.localPosition.z);
    }
    void FixedUpdate()
    {
       
       

        FindClosestEnemy();
       
       
    }
}
