using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hip : MonoBehaviour
{
    public bool inside;
    public GameObject Parent;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BusInside")
        {
            inside = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BusInside")
        {
            inside = false;
        }
    }
}
