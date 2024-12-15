using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeImages : MonoBehaviour
{
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private float fadeDuration1 = 2.0f;
    [SerializeField] private float fadeDuration2 = 4.0f;

    public void Start()
    {
        StartFade();
    }

    public void StartFade()
    {
        StartCoroutine(FadeImageIn(image1, fadeDuration1));
        StartCoroutine(FadeImageIn(image2, fadeDuration2));
    }

    private IEnumerator FadeImageIn(Image image, float duration)
    {
        float elapsedTime = 0f;
        Color originalColor = image.color;
        Color startColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); 
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); 

        image.color = startColor;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / duration);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        image.color = targetColor;
    }
}
