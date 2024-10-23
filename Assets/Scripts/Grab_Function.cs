using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Function : MonoBehaviour
{
    public GameObject grabber;
    public bool isHolding = false;


    void Update()
    {
        if (isHolding == true)
        {

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                grabber.transform.GetChild(0).SetParent(null);
                isHolding = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grabbable"))
        {

            if (isHolding == false /*&& Input.GetKeyDown(KeyCode.Space) == true*/)
            {

                
                    collision.gameObject.transform.SetParent(grabber.transform);
                    isHolding = true;
                
            }




        }
    }

}
