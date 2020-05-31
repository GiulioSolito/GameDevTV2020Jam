using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : Puzzle
{
    [SerializeField] private AudioClip doorOpenSound;
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

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        UIManager.Instance.HideKeypadUI();
    }

    void SendCodeToKeypad()
    {
        Keypad.Instance.SetCode(_codeToUnlock);
    }

    public override void OpenDoor()
    {
        AudioManager.Instance.PlaySound(doorOpenSound);
        base.OpenDoor();
        UIManager.Instance.HideKeypadUI();
    }

    void OnDisable()
    {
        Keypad._OnCorrectCodeEntered -= OpenDoor;
    }
}
