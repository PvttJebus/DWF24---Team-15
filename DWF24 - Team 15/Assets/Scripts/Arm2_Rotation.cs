using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm2_Rotation : MonoBehaviour
{

    public GameObject target;
    public float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) == true)
        {
            transform.RotateAround(target.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            Console.WriteLine("Test");
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.RotateAround(target.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
            Console.WriteLine("Test");
        }
    }
}
