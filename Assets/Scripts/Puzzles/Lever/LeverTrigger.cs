using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : Puzzle
{
    [SerializeField] private GameObject[] _levers;

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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
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
    }

    void OnDisable()
    {
        Lever.onLeverChanged -= SetEnteredCode;
    }
}
