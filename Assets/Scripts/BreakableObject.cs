using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Student" || collision.gameObject.layer==9 ||collision.gameObject.tag=="Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                transform.GetChild(i).gameObject.AddComponent<BoxCollider>();
                transform.GetChild(i).GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(-300, 300));
            }
        }
       
    }
}
