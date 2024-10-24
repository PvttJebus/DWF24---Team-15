using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
    public Animator rocketAnimator;

    void Start()
    {
        // Start the rocket animation
        rocketAnimator.SetTrigger("StartAnimation");

        // Start loading the main menu after the animation
        StartCoroutine(LoadMainMenuAfterAnimation());
    }

    private IEnumerator LoadMainMenuAfterAnimation()
    {
        // Get the length of the animation clip (ensure you set this accurately in the Animator)
        float animationLength = rocketAnimator.runtimeAnimatorController.animationClips[0].length;

        // Wait for the animation to finish
        yield return new WaitForSeconds(animationLength);

        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
