using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Junk_Bin : MonoBehaviour
{

    public Grab_Function grabber;
    public JunkValue Value;
    public int junkCollected = 0;
    public Text junkCollectedText;
    public int junkScore = 0;
    public Text junkScoreText;
    public Text timerText;
    public float timer = 120f;

    // Start is called before the first frame update
    void Start()
    {
        grabber = GameObject.Find("Grabber").GetComponent<Grab_Function>();
    }

    // Update is called once per frame
    void Update()
    {
        junkCollectedText.text = "Junk Collected: " + junkCollected.ToString();
        junkScoreText.text = "Score: " + junkScore.ToString();
        timerText.text = timer.ToString("F1");
        timer = timer - 1 * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Value = collision.gameObject.GetComponent<JunkValue>();

        if (collision.gameObject.CompareTag("Grabbable") == true)
        {


            Destroy(grabber.transform.GetChild(0).gameObject);
            grabber.isHolding = false;
            junkScore += Value.junkValue;
            timer += Value.timeValue;
            junkCollected++;

        }
    }
}
