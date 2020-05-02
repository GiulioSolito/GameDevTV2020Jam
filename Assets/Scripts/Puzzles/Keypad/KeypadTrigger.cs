using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    [SerializeField] private string _codeToUnlock = "0000";
    [SerializeField] private GameObject _doorToOpen;

    private bool _canInteract = false;
    private bool _doorOpened = false;

    void OnEnable()
    {
        Keypad._OnCorrectCodeEntered += OpenDoor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract && !_doorOpened)
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

    void OpenDoor()
    {
        Debug.Log("Destroying Door");
        Destroy(_doorToOpen);
        _doorOpened = true;
        UIManager.Instance.HideKeypadUI();
    }

    void OnDisable()
    {
        Keypad._OnCorrectCodeEntered -= OpenDoor;
    }
}
