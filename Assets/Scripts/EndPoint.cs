using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //GameManager.Instance.LoadNextLevel();
            UIManager.Instance.ShowWinScreen();
        }
    }
}
