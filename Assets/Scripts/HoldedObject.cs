using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldedObject : MonoBehaviour
{
    public bool meRight, meLeft;
    public GameObject Parent;
    public void Hold()
    {
        if (!CharacterCollider.instance.right && CharacterCollider.instance.left)
        {
            CharacterCollider.instance.right = true;
            meRight = true;
            CharacterCollider.instance.rightObject = transform.gameObject;
        }
        if (CharacterCollider.instance.right && !CharacterCollider.instance.left)
        {
            CharacterCollider.instance.left = true;
            meLeft = true;
            CharacterCollider.instance.leftObject = transform.gameObject;

        }
        if (!CharacterCollider.instance.right && !CharacterCollider.instance.left)
        {
            CharacterCollider.instance.right = true;
            meRight = true;
            CharacterCollider.instance.rightObject = transform.gameObject;

        }
        
    }
   
    private void FixedUpdate()
    {
       

        if (meRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterCollider.instance.rightArmChild.position,0.4f) ;
            
        }
        if (meLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterCollider.instance.leftArmChild.position, 0.4f);

        }
    }



   
}
