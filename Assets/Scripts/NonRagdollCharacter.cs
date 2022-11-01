using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRagdollCharacter : MonoBehaviour
{

    public DynamicJoystick Joys;
    public float Speed;
    public float TurnSpeed;
    public Animator anim;
    public Rigidbody rb;
    public ParticleSystem ps;
    float timer;
    float maxTime;
    void Start()
    {
        maxTime = Random.Range(4f, 8f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer+= Time.deltaTime;
        if (timer > maxTime)
        {
            maxTime = Random.Range(4f, 8f);
            timer = 0;
            ps.Play();
        }


        rb.velocity = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            JoystickMovement();
            anim.SetInteger("movement", 1);
            rb.isKinematic = false;
        }
        else
        {
            anim.SetInteger("movement", 0);
            rb.isKinematic = true;
        }
    }
    public void JoystickMovement()
    {
        float horizontal = Joys.Horizontal;
        float vertical = Joys.Vertical;
        Vector3 addedPos = new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime);
        }
       
    }
    
}

