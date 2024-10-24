using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectVelocity : MonoBehaviour
{

    Rigidbody2D ObjectRB;

    public float initialVelocity = 1.5f; //Velocity to apply to the game object
    bool applyVelocity = false;
    
    void Awake()
    {
        ObjectRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (applyVelocity) 
        {
            ObjectRB.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse); //Upon coliiding with any object applies velocity to it
            applyVelocity = false;
        }        
    }

    //Checks for collisions
    public void OnCollisionEnter2D(Collision2D collision)
    {
        applyVelocity = true;
    }

    //Death Function
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death Zone")
        {
            Destroy(gameObject);
        }
    }
}
