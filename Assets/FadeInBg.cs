using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInBg : MonoBehaviour
{
    public Animator fadeAnimator;

    void Start()
    {
        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        fadeAnimator.SetTrigger("StartFade"); // Trigger the fade in
        yield return new WaitForSeconds(4.3f); // IntroScene Length
        SceneManager.LoadScene("MainMenu"); // Starts Main Menu Scene
    }
}
