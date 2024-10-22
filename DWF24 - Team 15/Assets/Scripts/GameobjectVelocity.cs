using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectVelocity : MonoBehaviour
{
    public Grab_Function FreezeVelocity;

    Rigidbody2D ObjectRB;

    public float initialVelocity = 1.5f; //Velocity to apply to the game object
    float velocity;
    public GameObject gameObject;
    bool applyVelocity = false;
    
    void Awake()
    {
        ObjectRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /* Attempted to freeze object velocity when grabbed but couldn't figure out how without also freezeing everything else
        if (FreezeVelocity.isHolding == true)
        {
            velocity = 0;
        }        

        else
        {
            velocity = 1.5f;
        }
        */
        if (applyVelocity) 
        {
            ObjectRB.AddForce(Vector2.up * 1.5f /*<- Change this float to the velocity variable if you get the freeze velocity stuff working*/, ForceMode2D.Impulse); //Upon coliiding with any object applies velocity to it
            applyVelocity = false;
        }        
    }

    //Checks for collisions
    public void OnCollisionEnter2D(Collision2D collision)
    {
        applyVelocity = true;
    }
}
