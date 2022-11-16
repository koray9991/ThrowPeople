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
    public bool isInside;
    public static NonRagdollCharacter instance;
    public bool throwing;
    public float throwAnimationTime;
    float throwTimer;
    public float busTransform;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    void Start()
    {
        maxTime = Random.Range(4f, 8f);
    }

    private void Update()
    {
        if (throwing)
        {
            Speed = 0;
            transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetInteger("movement", 2);
            throwTimer += Time.deltaTime;
            if (throwTimer>throwAnimationTime)
            {
                throwing = false;
                
               
            }
        }
    }
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
       


       
        if (!throwing)
        {
            Speed = 5;
            throwTimer = 0;
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "HomeInside")
        {
            isInside = true;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].GetComponent<Wall>().Disactive();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HomeInside")
        {
            isInside = false;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].GetComponent<Wall>().Active();
            }
        }
    }
}

