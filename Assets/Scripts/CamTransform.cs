using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransform : MonoBehaviour
{
    public Transform rig;
    private void FixedUpdate()
    {
        transform.position = new Vector3(rig.position.x, transform.position.y, rig.position.z);
    }
}
