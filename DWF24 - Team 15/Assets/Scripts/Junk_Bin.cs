using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Junk_Bin : MonoBehaviour
{
    //Total items collected
    int junkCollected = 0;
    public Text junkCollectedText;
    
    //Total player score
    int totalScore = 0;
    public Text totalScoreText;

<<<<<<< Updated upstream
    //Value for each level of item, set in engine to desired value
    public int smallValue = 250;
    public int medValue = 500;
    public int largeValue = 750;
    public int legendaryValue = 1000;
<<<<<<< Updated upstream
=======

    //Bool to change the location of the bin
    bool switchFlipped;
>>>>>>> Stashed changes
=======
    //bool for moving the bin
    bool switchFlipped;

    // Start is called before the first frame update
    void Start()
    {
        grabber = GameObject.Find("Grabber").GetComponent<Grab_Function>();
    }
>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {
        //Display text to screen
        junkCollectedText.text = "Junk Collected: " + junkCollected.ToString();
<<<<<<< Updated upstream
        totalScoreText.text = "Score: " + totalScore.ToString();
<<<<<<< Updated upstream
=======

        //Check for switch flip and change location accordingly
        if(Input.GetButtonDown("Fire1"))
=======
        junkScoreText.text = "Score: " + junkScore.ToString();
        timerText.text = timer.ToString("F1");
        timer = timer - 1 * Time.deltaTime;

        //Check for switch flip and change location accordingly
        if (Input.GetButtonDown("Fire1"))
>>>>>>> Stashed changes
        {
            switchFlipped = true;
            gameObject.transform.position = new Vector3(5.09f, -3.65f, 0f);
            Debug.Log("Working 1");
        }
<<<<<<< Updated upstream
        if(Input.GetButtonUp("Fire1"))
=======
        if (Input.GetButtonUp("Fire1"))
>>>>>>> Stashed changes
        {
            switchFlipped = false;
            gameObject.transform.position = new Vector3(-5.09f, -3.65f, 0f);
            Debug.Log("Wotking 2");
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check the tag of each item we bring to the score zone, add the corresponding value to the total score, increase the count of items collected and destroy the gameobject
        if (collision.gameObject.CompareTag("Small Junk") == true)
        {
           totalScore = totalScore + smallValue;
           junkCollected++;
           Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Medium Junk") == true)
        {
            totalScore = totalScore + medValue;
            junkCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Large Junk") == true)
        {
            totalScore = totalScore + largeValue;
            junkCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Legendary Junk") == true)
        {
            totalScore = totalScore + legendaryValue;
            junkCollected++;
            Destroy(collision.gameObject);
        }
    }
}
