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

    //Value for each level of item, set in engine to desired value
    public int smallValue = 250;
    public int medValue = 500;
    public int largeValue = 750;
    public int legendaryValue = 1000;

    // Update is called once per frame
    void Update()
    {
        //Display text to screen
        junkCollectedText.text = "Junk Collected: " + junkCollected.ToString();
        totalScoreText.text = "Score: " + totalScore.ToString();
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
