using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BusGate : MonoBehaviour
{
    public GameObject bus;
    float z;
    public float moveSpeed;
    public float xRot, yRot, zRot;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (GameManager.instance.winBool)
        {
            transform.DOLocalRotateQuaternion(Quaternion.Euler(xRot, yRot, zRot), 0.5f);
            bus.transform.position = new Vector3(bus.transform.position.x, bus.transform.position.y, bus.transform.position.z + z);
            z += moveSpeed;
        }

    }
}
