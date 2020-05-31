using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            AudioManager.Instance.PlaySound(clip);
            StartCoroutine(WaitPitFall());

        }
    }

    IEnumerator WaitPitFall()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.RestartLevel();
    }
}
