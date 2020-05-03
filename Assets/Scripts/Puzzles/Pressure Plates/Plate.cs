using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public int plateNumber;
    public bool _isFlippedOn = false;
    public bool _addedPlateToCode = false;

    public delegate void OnPlateChanged();
    public static event OnPlateChanged onPlateChanged;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isFlippedOn = true;

            GetComponent<SpriteRenderer>().color = Color.magenta;

            if (onPlateChanged != null)
            {
                onPlateChanged();
            }
        }
    }
}
