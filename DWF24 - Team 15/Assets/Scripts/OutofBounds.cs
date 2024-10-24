using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Small Junk") == true)
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Medium Junk") == true)
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Large Junk") == true)
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Legendary Junk") == true)
        {
            Destroy(collision.gameObject);
        }

        else
        {
            Destroy(collision.gameObject);
        }
    }
}

