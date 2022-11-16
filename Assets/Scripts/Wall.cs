using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    

    public void Active()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
   public void Disactive()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
