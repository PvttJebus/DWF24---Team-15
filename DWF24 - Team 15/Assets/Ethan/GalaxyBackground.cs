using System.Collections.Generic;
using UnityEngine;

public class GalaxyBackground : MonoBehaviour
{
    public GameObject starPrefab;
    public int totalStars = 50;
    public int starsToManage = 15;
    public float animationDuration = 10f;
    public float fadeDuration = 1f;
    public float minDistance = 0.5f;

    private List<GameObject> stars = new List<GameObject>();
    private float spawnTimer;

    void Start()
    {
        foreach (var star in GameObject.FindGameObjectsWithTag("Star"))
            Destroy(star);

        for (int i = 0; i < totalStars; i++)
            SpawnStar();

        spawnTimer = animationDuration;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            ManageStars();
            spawnTimer = animationDuration;
        }

        foreach (var star in stars)
            UpdateStarFade(star);
    }

    private void SpawnStar()
    {
        Vector2 position;
        do { position = GenerateRandomPosition(); } while (IsOverlapping(position));

        var newStar = Instantiate(starPrefab, position, Quaternion.identity);
        newStar.tag = "Star";
        stars.Add(newStar);

        var spriteRenderer = newStar.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0); // Start transparent
        newStar.AddComponent<StarFade>().isFadingIn = true;

        SetStarProperties(newStar);
    }

    private void ManageStars()
    {
        for (int i = 0; i < starsToManage && stars.Count > 0; i++)
        {
            var starToManage = stars[Random.Range(0, stars.Count)];
            var starFade = starToManage.GetComponent<StarFade>();

            if (!starFade.isFadingOut) // Only manage if not already fading
            {
                StartCoroutine(FadeOutAndReposition(starToManage));
            }
        }
    }

    private System.Collections.IEnumerator FadeOutAndReposition(GameObject star)
    {
        // Fade out
        var spriteRenderer = star.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }
        color.a = 0;
        spriteRenderer.color = color;

        // Remove star from the list and destroy it
        stars.Remove(star);
        Destroy(star);

        // Spawn a new star in a new position
        SpawnStar();
    }

    private void UpdateStarFade(GameObject star)
    {
        var spriteRenderer = star.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        var starFade = star.GetComponent<StarFade>();

        if (starFade.isFadingIn)
        {
            color.a += Time.deltaTime / fadeDuration;
            if (color.a >= 1) { color.a = 1; starFade.isFadingIn = false; }
        }
        else if (starFade.isFadingOut)
        {
            color.a -= Time.deltaTime / fadeDuration;
            if (color.a <= 0) { color.a = 0; starFade.isFadingOut = false; }
        }

        spriteRenderer.color = color;
    }

    private void SetStarProperties(GameObject star)
    {
        float randomSize = Random.Range(0.2f, 0.6f);
        star.transform.localScale = new Vector3(randomSize, randomSize, 1);

        var animator = star.GetComponent<Animator>();
        if (animator != null)
        {
            animator.speed = Random.Range(0.5f, 2.0f);
            animator.Play("StarAnimation");
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        var mainCamera = Camera.main;
        return new Vector2(
            Random.Range(-mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize * mainCamera.aspect),
            Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize)
        );
    }

    private bool IsOverlapping(Vector2 position)
    {
        foreach (var star in stars)
            if (Vector2.Distance(star.transform.position, position) < minDistance)
                return true;

        return false;
    }
}

// Stars fade
public class StarFade : MonoBehaviour
{
    public bool isFadingIn;
    public bool isFadingOut;
}
