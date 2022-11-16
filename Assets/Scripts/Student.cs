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
    public GameObject[] goToTransform;
    public float moveSpeed;
    int goToInteger;
    public GameObject arrow;
    private void Start()
    {
        randomTime = Random.Range(4f, 8f);
    }
    private void FixedUpdate()
    {
        if (goToTransform.Length != 0 && GetComponent<Animator>().enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, goToTransform[goToInteger].transform.position, moveSpeed/100);
            transform.LookAt(goToTransform[goToInteger].transform);
            if(Vector3.Distance(transform.position, goToTransform[goToInteger].transform.position) < 0.3f)
            {
                if (goToTransform.Length == goToInteger + 1)
                {
                    goToInteger = 0;
                }
                else
                {
                    goToInteger += 1;
                }
               
            }
        }
        if (state == 2 && arrow != null)
        {
            if (arrow.activeSelf)
            {
                arrow.SetActive(false);
            }
        }


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
