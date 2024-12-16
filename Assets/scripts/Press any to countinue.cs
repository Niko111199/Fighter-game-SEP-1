using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TextFade : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text textField;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private int MenuScene;

    public SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;

        if (soundManager == null)
        {
            Console.WriteLine("Something bad happened");
        }
        StartCoroutine(FadeText());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            soundManager.PlayAudio(AudioType.SFX_01);
            SceneManager.LoadScene(MenuScene);
        }
    }

    private IEnumerator FadeText()
    {
        Color targetColor = textField.color;
        float alphaValue = 0f;

        while (true)
        {
            
            while (alphaValue < 1f)
            {
                alphaValue += Time.deltaTime * fadeSpeed;
                textField.color = new Color(targetColor.r, targetColor.g, targetColor.b, Mathf.PingPong(alphaValue, 1));
                yield return null;
            }

          
            while (alphaValue > 0f)
            {
                alphaValue -= Time.deltaTime * fadeSpeed;
                textField.color = new Color(targetColor.r, targetColor.g, targetColor.b, Mathf.PingPong(alphaValue, 1));
                yield return null;
            }
        }
    }
}
