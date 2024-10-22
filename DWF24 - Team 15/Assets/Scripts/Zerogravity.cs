using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zerogravity : MonoBehaviour
{

    public Rigidbody2D rbd2;

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        rbd2.gravityScale = 0f;
        rbd2.drag = 0f;
        rbd2.angularDrag = 0f;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    rbd2.AddForce(collision.gameObject.velocity * 100f);
    //}
}
