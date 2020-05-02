using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    [SerializeField] private string _codeToUnlock = "0000";

    private bool _canInteract = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            UIManager.Instance.ShowKeypadUI();
            SendCodeToKeypad();
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
            UIManager.Instance.HideKeypadUI();
        }
    }

    void SendCodeToKeypad()
    {
        Keypad.Instance.SetCode(_codeToUnlock);
    }
}
