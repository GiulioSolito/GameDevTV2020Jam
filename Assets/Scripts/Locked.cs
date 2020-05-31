using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.PlaySound(clip); 
    }
}
