using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Material[] mats;
    public bool inside;
    

    
    void Update()
    {
        if (inside)
        {
            GetComponent<MeshRenderer>().material = mats[1];
        }
        else
        {
            GetComponent<MeshRenderer>().material = mats[0];
        }
    }
}
