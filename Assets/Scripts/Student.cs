using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public ParticleSystem psFree,psSleep,psHolded;
    public int state; // 0-free, 1-sleep, 2-holded
    public float timer;
    public float randomTime;
    public GameObject rig;
   
    private void Start()
    {
        randomTime = Random.Range(4f, 8f);
    }
    private void FixedUpdate()
    {
        



        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            timer = 0;
            randomTime = Random.Range(4f, 8f);
            if (state == 0)
            {
                psFree.Play();
            }
            if (state == 1)
            {
                psSleep.Play();
            }
            if (state == 2)
            {
                psHolded.Play();
            }
        }
    }

   

   
}
