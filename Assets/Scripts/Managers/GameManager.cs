using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int _timeRemaining = 300;

    private bool _decreaseTime = true;
    private bool _isGameOver = false;

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
            if (_timeRemaining <= 0)
            {
                _decreaseTime = false;
                _timeRemaining = 0;
                Debug.Log("GAME OVER!");
            }
            else
            {
                _timeRemaining--;
                UIManager.Instance.UpdateTimeTextUI(_timeRemaining);
                yield return new WaitForSeconds(1f);
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDisable()
    {
        PlayerController.onPauseGame -= PauseGame;
        PlayerController.onResumeGame -= ResumeGame;
        UIManager.onResumeButtonClicked -= ResumeGame;
    }
}
