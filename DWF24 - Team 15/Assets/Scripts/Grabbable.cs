using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    GameObject Claw;
    //Script to freeze the pos XYZ of the space junk gameobject and set it to the position of the claw gameobject
    bool isColliding;
    bool isHolding;
    bool buttonClick;

    // Update is called once per frame
    void Update()
    {
        /*
         * Dropped items still on screen will be sucked back to claw for some reason
         */
        //check for button press
        if (isColliding == true && Input.GetButtonDown("Grab"))
        {             
            buttonClick = !buttonClick;
        }
        if (buttonClick)
        {
            gameObject.transform.SetPositionAndRotation(Claw.transform.position, Claw.transform.rotation); //Set the position and rotation of the gameobject to the claw position
            isHolding = true;
        }
        else
        {
            isHolding = false;            
            gameObject.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);          
        }
    }

    //check if we are colliding with the claw
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Claw") 
        { 
            isColliding = true;
            Claw = collision.gameObject;
            Debug.Log("Colliding");
        }
    }
}
