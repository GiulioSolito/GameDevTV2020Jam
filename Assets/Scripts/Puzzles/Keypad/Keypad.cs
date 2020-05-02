using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoSingleton<Keypad>
{
    [SerializeField] private string _codeToUnlock = "0000";         
    [SerializeField] private string _codeEntered;                   //TODO: Change to private later, no need to see it
    [SerializeField] private TextMeshProUGUI _codeText;
    [SerializeField] private int _maxAllowedNumbers = 4;

    // Start is called before the first frame update
    void OnEnable()
    {
        _codeEntered = "";
        _codeText.text = "CODE";
    }

    public void SetCode(string code)
    {
        _codeToUnlock = code;
    }

    public void AddKeyToCode(string key)
    {
        if (_codeEntered.Length < _maxAllowedNumbers)
        {
            _codeEntered += key;
            _codeText.text = _codeEntered;
        }        
    }

    public void SubmitCode()
    {
        if (_codeText.text == _codeToUnlock)
        {
            Debug.Log("You have entered the correct code!");
        }
        else
        {
            Debug.Log("You have entered the incorrect code!");
            _codeEntered = "";
            _codeText.text = "";
        }
    }

    public void ClearCode()
    {
        _codeEntered = "";
        _codeText.text = "";
    }
}
