using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLight : MonoBehaviour
{
    float timer;
    public float time;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < time)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (timer > time && timer<time*2)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (timer > time*2)
        {
            timer = 0;
        }
    }
}
