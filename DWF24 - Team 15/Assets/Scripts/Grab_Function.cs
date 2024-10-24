using UnityEngine;

public class Grab_Function : MonoBehaviour
{
    public GameObject grabber;
    public GameobjectVelocity goVelocity;
    public Vector3 objectVector;
    public Quaternion objectQuaternion;
    public bool isHolding = false;

    void Update()
    {
        if (isHolding == true)
        {
            // Ensure the grabbed object is parented to the grabber and doesn't move
            grabber.transform.GetChild(0).SetParent(grabber.transform);
            goVelocity.applyVelocity = false;
            grabber.transform.GetChild(0).transform.SetPositionAndRotation(grabber.transform.position, grabber.transform.rotation);



            // Freeze the Rigidbody2D to stop any movement
            goVelocity.ObjectRB.velocity = Vector2.zero;
            goVelocity.ObjectRB.isKinematic = true;  // Disable physics simulation

            // Release the object when the spacebar is pressed
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                grabber.transform.GetChild(0).transform.SetPositionAndRotation(objectVector, objectQuaternion);
                grabber.transform.GetChild(0).SetParent(null);
                goVelocity.ObjectRB.isKinematic = false;  // Re-enable physics simulation
                
                isHolding = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grabbable"))
        {
            goVelocity = collision.gameObject.GetComponent<GameobjectVelocity>();

            if (isHolding == false)
            {
                // Grab the object, parent it, and stop its movement
                collision.gameObject.transform.SetParent(grabber.transform);
                collision.gameObject.transform.SetPositionAndRotation(grabber.transform.position, grabber.transform.rotation);
                goVelocity.ObjectRB.velocity = Vector2.zero;
                goVelocity.ObjectRB.isKinematic = true;  // Disable physics simulation
                goVelocity.applyVelocity = false;
                isHolding = true;
                objectVector = collision.gameObject.transform.position;
                objectQuaternion = collision.gameObject.transform.rotation;
            }
        }
    }
}
