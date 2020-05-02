using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int _timeRemaining = 300;

    private bool _decreaseTime = true;
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateTimeTextUI(_timeRemaining);

        StartCoroutine(DecreaseTime());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
