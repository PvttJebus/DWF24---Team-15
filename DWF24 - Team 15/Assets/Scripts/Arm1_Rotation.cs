using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Arm1_Rotation : MonoBehaviour
{

    public GameObject target;
    public float rotationSpeed = 10f;
    public InputAction Joystick;
    public InputActionMap canArm;
    // Start is called before the first frame update
    void Start()
    {
        Joystick = GetComponent<InputAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) == true /*|| Joystick.*/)
        {
            transform.RotateAround(target.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            Console.WriteLine("Test");
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.RotateAround(target.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
            Console.WriteLine("Test");
        }
    }
}
