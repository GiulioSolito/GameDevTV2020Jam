using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Rigidbody2D _rb;
    private Animator _anim;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_anim = GetComponent<Animator>();

        if (_rb == null)
        {
            Debug.LogError("The Player Rigidbody is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
