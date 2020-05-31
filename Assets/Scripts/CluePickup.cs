using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePickup : MonoBehaviour
{
    [TextArea(5, 10)]
    [SerializeField] private string _clueText;
    [SerializeField] private AudioClip clip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlaySound(clip);
            ClueManager.Instance.SetClueText(_clueText);
            Destroy(gameObject);
        }
    }
}
