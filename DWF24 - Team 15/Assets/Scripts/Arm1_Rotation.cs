using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arm1_Rotation : MonoBehaviour
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
        if (Input.GetKey(KeyCode.E) == true)
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
