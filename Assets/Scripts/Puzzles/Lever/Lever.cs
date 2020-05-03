using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool _isFlippedOn = false;
    private bool _desiredFlippedPosition = true;
    private int _leverIndex = 0;
    private bool _canInteract = false;

    public delegate void OnLeverChanged(int index);
    public static event OnLeverChanged onLeverChanged;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            _isFlippedOn = !_isFlippedOn;

            if (onLeverChanged != null)
            {
                onLeverChanged(_leverIndex);
            }
        }
    }

    public void SetUp(int index, bool desiredActivation)
    {
        _leverIndex = index;
        _desiredFlippedPosition = desiredActivation;
    }

    public bool IsCorrect()
    {
        return _isFlippedOn != _desiredFlippedPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;
        }
    }
}
