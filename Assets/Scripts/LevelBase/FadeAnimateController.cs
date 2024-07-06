using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimateController : MonoBehaviour
{
        public float fadeDuration = 1f; // 渐变持续时间
    public float targetAlpha = 0.5f; // 目标透明度

    private Image image;
    private float currentAlpha;
    private float timer;
    private bool isFading;

    private void Start()
    {
        image = GetComponent<Image>();
        currentAlpha = image.color.a;
    }

    private void Update()
    {
        if (isFading)
        {
            timer += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / fadeDuration);
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, normalizedTime);

            SetAlpha(newAlpha);

            if (normalizedTime >= 1f)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeIn()
    {
        StartFade(0f, 1f);
    }

    public void StartFadeOut()
    {
        StartFade(1f, 0f);
    }

    private void StartFade(float startAlpha, float endAlpha)
    {
        currentAlpha = startAlpha;
        targetAlpha = endAlpha;
        timer = 0f;
        isFading = true;
    }

    private void SetAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}