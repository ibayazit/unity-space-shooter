using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Canvas gameUI;

    private void OnEnable()
    {
        GameManager.Instance.OnGamePaused += OnGamePaused;
        if (GameManager.Instance.isGamePaused)
        {
            ShowUI();
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGamePaused -= OnGamePaused;
    }

    private void OnGamePaused(bool isPaused)
    {
        if (isPaused)
        {
            ShowUI();
        }
        else
        {
            HideUI();
        }
    }

    private void ShowUI()
    {
        gameUI.gameObject.SetActive(true);
    }

    private void HideUI()
    {
        gameUI.gameObject.SetActive(false);
    }
}
