using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueManager : MonoSingleton<ClueManager>
{
    [SerializeField] private GameObject _clueMenu;
    [SerializeField] private TextMeshProUGUI _clueText;

    public void SetClueText(string clueText)
    {
        _clueText.text = clueText;
        OpenClueMenu();
    }

    public void OpenClueMenu()
    {
        _clueMenu.SetActive(true);
    }

    public void CloseClueMenu()
    {
        _clueMenu.SetActive(false);
    }
}
