using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int _timeRemaining = 300;

    private bool _decreaseTime = true;

    public bool IsGameOver { get; private set; }

    void OnEnable()
    {
        PlayerController.onPauseGame += PauseGame;
        PlayerController.onResumeGame += ResumeGame;
        UIManager.onResumeButtonClicked += ResumeGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateTimeTextUI(_timeRemaining);

        StartCoroutine(DecreaseTime());
    }

    IEnumerator DecreaseTime()
    {
        while (_decreaseTime)
        {
            _timeRemaining--;
            UIManager.Instance.UpdateTimeTextUI(_timeRemaining);
            yield return new WaitForSeconds(1f);

            switch (_timeRemaining)
            {
                case 60:
                    AudioManager.Instance.PlayMusic(1);
                    break;
                case 30:
                    AudioManager.Instance.PlayMusic(2);
                    break;
                case 11:
                    AudioManager.Instance.PlayMusic(3);
                    break;
                case 0:
                    _decreaseTime = false;
                    _timeRemaining = 0;
                    AudioManager.Instance.PlayMusic(4);
                    GameOver();
                    break;
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0;
        UIManager.Instance.ShowGameOver();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDisable()
    {
        PlayerController.onPauseGame -= PauseGame;
        PlayerController.onResumeGame -= ResumeGame;
        UIManager.onResumeButtonClicked -= ResumeGame;
    }
}
