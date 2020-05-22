using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _keyPadUI;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _optionsMenu;    

    public delegate void OnResumeButtonClicked();
    public static event OnResumeButtonClicked onResumeButtonClicked;

    void OnEnable()
    {
        PlayerController.onPauseGame += ShowPauseMenu;
        PlayerController.onResumeGame += HidePauseMenu;
        PlayerController.onResumeGame += HideOptionsMenu;
    }

    public void UpdateTimeTextUI(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string timeRemaining = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timeText.text = timeRemaining;
    }

    public void ShowKeypadUI()
    {
        _keyPadUI.SetActive(true);
    }

    public void HideKeypadUI()
    {
        _keyPadUI.SetActive(false);
    }

    #region Pause Menu
    void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
    
    void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        if (onResumeButtonClicked != null)
        {
            onResumeButtonClicked();
        }
    }

    public void Options()
    {
        _optionsMenu.SetActive(true);
    }

    void HideOptionsMenu()
    {
        _optionsMenu.SetActive(false);
    }

    public void Done()
    {
        _optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    #endregion



    void OnDisable()
    {
        PlayerController.onPauseGame -= ShowPauseMenu;
        PlayerController.onResumeGame -= HidePauseMenu;
        PlayerController.onResumeGame -= HideOptionsMenu;
    }
}
