using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : Puzzle
{
    [SerializeField] private GameObject[] _levers;

    [SerializeField] private AudioClip _correctSoundClip;
    [SerializeField] private AudioClip _inCorrectSoundClip;

    void OnEnable()
    {
        Lever.onLeverChanged += SetEnteredCode;
    }

    void Update()
    {
        if (_codeEntered == _codeToUnlock)
        {
            Debug.Log("Correct lever order: Openening Door");
            OpenDoor();
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

    public void SetEnteredCode()
    {
        foreach (var lever in _levers)
        {
            Lever leverScript = lever.GetComponent<Lever>();
            int leverValue = Convert.ToInt32(leverScript._isFlippedOn);

            if (leverScript != null)
            {
                if (_codeEntered.Length < _levers.Length)
                {
                    _codeEntered += leverValue;
                }
                else
                {
                    _codeEntered = "";
                    _codeEntered += leverValue;
                }
            }
        }
        CompareCodesAndCheckIfCorrect();
    }

    void CompareCodesAndCheckIfCorrect()
    {
        for (int i = 0; i < _codeEntered.Length; i++)
        {

            if (_codeEntered[i] != _codeToUnlock[i])
            {
                _levers[i].GetComponent<Lever>().isCorrectPosition = false;
                Debug.Log("Incorrect Lever");
                //TODO: Play incorrect sound clip            
                AudioManager.Instance.PlaySound(_inCorrectSoundClip);
            }
            else
            {
                _levers[i].GetComponent<Lever>().isCorrectPosition = true;
                Debug.Log("Correct Lever");
                //TODO: Play correct sound clip
                AudioManager.Instance.PlaySound(_correctSoundClip);
            }
        }
    }

    void OnDisable()
    {
        Lever.onLeverChanged -= SetEnteredCode;
    }
}
