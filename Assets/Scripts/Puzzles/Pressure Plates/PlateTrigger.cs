using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : Puzzle
{
    [SerializeField] private GameObject[] _plates;

    [SerializeField] private bool _codeSolved = false;                                      //TODO: make private later

    void OnEnable()
    {
        Plate.onPlateChanged += SetEnteredCode;
    }

    void Update()
    {
        if (_codeEntered == _codeToUnlock)
        {
            Debug.Log("Correct plate order: Openening Door");
            _codeSolved = true;
            OpenDoor();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;
            ResetPlates();
        }
    }

    public void SetEnteredCode()
    {
        foreach (var plate in _plates)
        {
            Plate plateScript = plate.GetComponent<Plate>();

            if (plateScript != null)
            {
                if (_codeEntered.Length < _plates.Length && plateScript._isFlippedOn && !plateScript._addedPlateToCode)
                {
                    _codeEntered += plateScript.plateNumber;
                    plateScript._addedPlateToCode = true;
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
                Debug.Log("Incorrect Plate");
                ResetPlates();
            }
            else
            {
                Debug.Log("Correct Plate");
            }
        }
    }

    void ResetPlates()
    {        
        _codeEntered = "";

        if (!_codeSolved)
        {
            DeactivatePlates();
        }
    }

    void DeactivatePlates()
    {
        foreach (var plate in _plates)
        {
            plate.GetComponent<Plate>()._isFlippedOn = false;
            plate.GetComponent<Plate>()._addedPlateToCode = false;
            plate.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnDisable()
    {
        Plate.onPlateChanged -= SetEnteredCode;
    }
}
