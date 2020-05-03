using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : Puzzle
{
    [SerializeField] private GameObject[] _levers;
    private List<Lever> leverScripts;

    [SerializeField] private AudioClip _correctSoundClip;
    [SerializeField] private AudioClip _inCorrectSoundClip;

    void OnEnable()
    {
        Lever.onLeverChanged += SetEnteredCode;

        leverScripts = new List<Lever>();
        for (int i = 0; i < _levers.Length; i++)
        {
            leverScripts.Add(_levers[i].GetComponent<Lever>());
            leverScripts[i].SetUp(i, _codeToUnlock[i] == '1');
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;
            _codeEntered = "";
        }
    }

    public void SetEnteredCode(int index)
    {
        string entered = "";
        foreach (var leverScript in leverScripts)
        {
            entered += Convert.ToInt32(leverScript._isFlippedOn);
        }
        _codeEntered = entered;
        CompareCodesAndCheckIfCorrect(index);
    }

    void CompareCodesAndCheckIfCorrect(int index)
    {
        if (leverScripts[index].IsCorrect())
        {
            Debug.Log("Incorrect Lever");
            AudioManager.Instance.PlaySound(_inCorrectSoundClip);
        }
        else
        {
            Debug.Log("Correct Lever");
            AudioManager.Instance.PlaySound(_correctSoundClip);
            CheckCodeIfMatch();
        }
    }

    void CheckCodeIfMatch()
    {
        if (_codeEntered == _codeToUnlock)
        {
            Debug.Log("Correct lever order: Openening Door");
            OpenDoor();
        }
    }

    void OnDisable()
    {
        Lever.onLeverChanged -= SetEnteredCode;
    }
}
