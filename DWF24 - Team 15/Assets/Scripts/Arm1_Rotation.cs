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
    public JoystickController joystickController;
    // Start is called before the first frame update
    void Start()
    {
        joystickController = new JoystickController();
        joystickController.CanArmControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float joystickXValue = joystickController.CanArmControls.joystickX.ReadValue<float>();
        if (Mathf.Abs(joystickXValue) > 0.1f)  // Add a threshold to prevent unintentional slight movements
        {
            transform.RotateAround(target.transform.position, Vector3.forward, joystickXValue * rotationSpeed * Time.deltaTime);
            Debug.Log("Joystick Input Detected: Rotating based on input");
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.RotateAround(target.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
            Console.WriteLine("Test");
        }
    }
}
