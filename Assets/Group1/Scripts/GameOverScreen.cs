using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private int _fadeInIterations;
    [SerializeField] private GameOver _gameOver;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _gameOver.AllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnDisable()
    {
        _gameOver.AllEnemiesDied -= OnAllEnemiesDied;
    }

    private IEnumerator FadeIn()
    {
        float transparency = _canvasGroup.alpha;

        for (int i = 0; i < _fadeInIterations; i++)
        {
            transparency = 0f + (1f / _fadeInIterations * i);
            _canvasGroup.alpha = transparency;

            yield return null;
        }
    }

    private void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    private void OnAllEnemiesDied()
    {
        StartFadeIn();
    }
}
