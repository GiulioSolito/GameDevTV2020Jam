using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _keyPadUI;

    public void UpdateTimeTextUI(int time)
    {
        _timeText.text = "Time: " + time;
    }

    public void ShowKeypadUI()
    {
        _keyPadUI.SetActive(true);
    }

    public void HideKeypadUI()
    {
        _keyPadUI.SetActive(false);
    }
}
