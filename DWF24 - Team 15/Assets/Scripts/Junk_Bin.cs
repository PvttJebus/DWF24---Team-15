using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Junk_Bin : MonoBehaviour
{

    
    public JunkValue Value;
    public int junkCollected = 0;
    public Text junkCollectedText;
    public int junkScore = 0;
    public Text junkScoreText;
    public Text timerText;
    public float timer = 120f;


    //Value for each level of item, set in engine to desired value
    public int smallValue = 250;
    public int medValue = 500;
    public int largeValue = 750;
    public int legendaryValue = 1000;

    // Update is called once per frame
    void Update()
    {
        junkCollectedText.text = "Junk Collected: " + junkCollected.ToString();

        junkScoreText.text = "Score: " + junkScore.ToString();
        timerText.text = timer.ToString("F1");
        timer = timer - 1 * Time.deltaTime;

        //Check for switch flip and change location accordingly
        if (Input.GetButtonDown("Fire1"))
        {        
            gameObject.transform.position = new Vector3(5.09f, -3.65f, 0f);
            Debug.Log("Working 1");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            
            gameObject.transform.position = new Vector3(-5.09f, -3.65f, 0f);
            Debug.Log("Wotking 2");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Value = collision.gameObject.GetComponent<JunkValue>();

        if (collision.gameObject.CompareTag("Grabbable") == true)
        {
            Debug.Log("Colliding with grabbable");

            //Destroy(grabber.transform.GetChild(0).gameObject);
            Destroy(collision.gameObject);
            junkScore += Value.junkValue;
            timer += Value.timeValue;
            junkCollected++;

        }
    }
}
