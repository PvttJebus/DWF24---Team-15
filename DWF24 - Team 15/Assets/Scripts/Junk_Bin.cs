using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Junk_Bin : MonoBehaviour
{

    public Grab_Function grabber;
    // Start is called before the first frame update
    void Start()
    {
        grabber = GameObject.Find("Grabber").GetComponent<Grab_Function>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
   {

        if (collision.gameObject.CompareTag("Grabbable") == true && grabber.isHolding == true)
        {
            
                Destroy(grabber.grabber.transform.GetChild(0).gameObject);
                grabber.isHolding = false;
            
        }
    }
}
