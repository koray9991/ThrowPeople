using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazo : MonoBehaviour
{
   
    float timer;

    private void Update()
    {
        if (timer < 2) { timer += Time.deltaTime; }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (timer >= 1)
        {
            GetComponent<BoxCollider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                transform.GetChild(i).gameObject.AddComponent<BoxCollider>();
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(-300, 300));
            }
        }
      
    }
}
