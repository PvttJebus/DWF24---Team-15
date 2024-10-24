using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    //Script to freeze the pos XYZ of the space junk gameobject and set it to the position of the claw gameobject
    public GameObject Claw;
    bool isColliding;

    // Update is called once per frame
    void Update()
    {
        //check for button press
        if (isColliding == true)
        {
            if (Input.GetButton("Grab"))
            {               
                gameObject.transform.SetPositionAndRotation(Claw.transform.position, Claw.transform.rotation); //Set the position and rotation of the gameobject to the claw position
            }
            if (Input.GetButtonUp("Grab"))
            {
                isColliding = false;
            }
        }
    }

    //check if we are colliding with the claw
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Claw) 
        { 
            isColliding = true;
        }
    }
}