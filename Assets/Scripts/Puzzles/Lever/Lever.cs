using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool _isFlippedOn = false;
    private bool _canInteract = false;

    public int leverIndex;
    public bool isCorrectPosition;

    public delegate void OnLeverChanged();
    public static event OnLeverChanged onLeverChanged;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            _isFlippedOn = !_isFlippedOn;

            if (onLeverChanged != null)
            {
                onLeverChanged();
            }
        }
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
