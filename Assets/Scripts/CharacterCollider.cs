using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    public List<GameObject> HoldableObject;
    public static CharacterCollider instance;
    public bool right, left;
    public Transform leftArmChild, rightArmChild;
    GameObject throwedRightObject, throwedLeftObject;
    public GameObject leftObject, rightObject;
    // public float throwForce;
    public float throwForceY, throwForceZ ;
    public Transform busTransform;
    public GameObject rightHip, leftHip;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Student" && (!right || !left) && !other.GetComponent<Hip>().inside)
        {
            other.GetComponent<Hip>().Parent.GetComponent<Animator>().enabled = false;
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.gameObject.layer = 9;

            other.GetComponent<Hip>().Parent.GetComponent<Student>().state = 2;
            var children = other.GetComponent<Hip>().Parent.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
               
                child.gameObject.layer = 9;
               
                if (child.GetComponent<HoldedObject>() != null)
                {
                    child.GetComponent<Rigidbody>().useGravity = true;
                    HoldableObject.Add(child.gameObject);
                   
                }
            }
            int ChoosePart = Random.Range(0, HoldableObject.Count);
            HoldableObject[ChoosePart].GetComponent<HoldedObject>().enabled = true;
            HoldableObject[ChoosePart].GetComponent<HoldedObject>().Hold();
            HoldableObject[ChoosePart].GetComponent<Rigidbody>().mass = 1000;
            HoldableObject[ChoosePart].GetComponent<Rigidbody>().drag = 10;
           // HoldableObject[ChoosePart].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            HoldableObject.Clear();
           


        }
        if (other.tag == "ThrowArea")
        {
            if (leftObject != null)
            {
                
                leftObject.GetComponent<HoldedObject>().meLeft = false;
                leftObject.GetComponent<HoldedObject>().meRight = false;
                leftObject.GetComponent<HoldedObject>().enabled = false;
                leftObject.GetComponent<Rigidbody>().mass = 1;
                leftObject.GetComponent<Rigidbody>().drag = 0;
                //leftObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeRotation;
                var children = leftObject.GetComponent<HoldedObject>().Parent.GetComponentsInChildren<Transform>(includeInactive: true);
                foreach (var child in children)
                {
                    if (child.GetComponent<Rigidbody>() != null)
                    {
                        child.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }



                
                leftObject.GetComponent<HoldedObject>().Parent.GetComponent<Student>().rig.GetComponent<Rigidbody>().AddForce(0, throwForceY, throwForceZ);
                
                throwedLeftObject = leftObject;
                leftObject.GetComponent<HoldedObject>().Parent.gameObject.layer = 0;
                leftObject = null;
                left = false;
               
                
            }
            if (rightObject != null)
            {
              
                rightObject.GetComponent<HoldedObject>().meLeft = false;
                rightObject.GetComponent<HoldedObject>().meRight = false;
                rightObject.GetComponent<HoldedObject>().enabled = false;
                rightObject.GetComponent<Rigidbody>().mass = 1;
                rightObject.GetComponent<Rigidbody>().drag = 0;
               // rightObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeRotation;
                var children = rightObject.GetComponent<HoldedObject>().Parent.GetComponentsInChildren<Transform>(includeInactive: true);
                foreach (var child in children)
                {
                    if (child.GetComponent<Rigidbody>() != null)
                    {
                        child.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                rightObject.GetComponent<HoldedObject>().Parent.GetComponent<Student>().rig.GetComponent<Rigidbody>().AddForce(0, throwForceY, throwForceZ);
               
                
               
                throwedRightObject = rightObject;
                StartCoroutine(Throw());

                rightObject.GetComponent<HoldedObject>().Parent.gameObject.layer = 0;
                rightObject = null;
                right = false;
               
               
            }
        }
    }
    IEnumerator Throw()
    {
        yield return new WaitForSeconds(2f);
        if (throwedRightObject != null)
        {
            var children = throwedRightObject.GetComponent<HoldedObject>().Parent.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = 0;
            }
            throwedRightObject.GetComponent<HoldedObject>().Parent.GetComponent<Student>().rig.GetComponent<CapsuleCollider>().enabled = true;


            throwedRightObject = null;
        }
        if (throwedLeftObject != null)
        {
            var children = throwedLeftObject.GetComponent<HoldedObject>().Parent.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = 0;
            }
            throwedLeftObject.GetComponent<HoldedObject>().Parent.GetComponent<Student>().rig.GetComponent<CapsuleCollider>().enabled = true;
           

            throwedLeftObject = null;
        }
    }
}
