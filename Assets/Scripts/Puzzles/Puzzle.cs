using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField] protected string _codeToUnlock = "0000";
    [SerializeField] protected string _codeEntered;
    [SerializeField] protected GameObject _doorToOpen;

    protected bool _canInteract = false;
    protected bool _doorOpened = false;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;            
        }
    }

    public virtual void OpenDoor()
    {
        if (_doorToOpen != null)
        {
            Destroy(_doorToOpen);
            Destroy(gameObject);
        }

        _doorOpened = true;        
    }
}
