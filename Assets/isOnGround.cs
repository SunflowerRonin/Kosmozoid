using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isOnGround : MonoBehaviour
{
    [SerializeField] bool isGrounded = true;

    void Update()
    {
        if (isGrounded == true)
        {
            //Do your action Here...
        }
    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Planet"))
        {
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Planet"))
        {
            isGrounded = false;
        }
    }
}