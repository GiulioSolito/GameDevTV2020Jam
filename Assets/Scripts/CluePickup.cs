using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePickup : MonoBehaviour
{
    [TextArea(5, 10)]
    [SerializeField] private string _clueText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ClueManager.Instance.SetClueText(_clueText);
            Destroy(gameObject);
        }
    }
}
