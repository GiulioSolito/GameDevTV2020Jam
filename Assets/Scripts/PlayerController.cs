
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private AudioClip[] _footsteps;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _lookDirection;
    private AudioSource _audio;

    public bool canMove = true;

    public delegate void OnPauseGame();
    public static event OnPauseGame onPauseGame;
    public delegate void OnResumeGame();
    public static event OnResumeGame onResumeGame;

    void OnEnable()
    {
        UIManager.onResumeButtonClicked += ReenablePlayerMovement;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _lookDirection = new Vector2(0, -1);
        _audio = GetComponent<AudioSource>();
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
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 move = new Vector2(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) ||
                !Mathf.Approximately(move.y, 0.0f))
            {
                _lookDirection.Set(move.x, move.y);
                _lookDirection.Normalize();
            }

            _anim.SetFloat("Look X", _lookDirection.x);
            _anim.SetFloat("Look Y", _lookDirection.y);
            _anim.SetFloat("Speed", move.magnitude);
            _rb.velocity = new Vector2(horizontal, vertical) * _speed;           
        }
        else
        {
            _rb.velocity = Vector2.zero;
            AudioManager.Instance.StopSound();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canMove)
            {
                DisablePlayerMovement();
            }
            else
            {
                ReenablePlayerMovement();
            }
        }
    }

    public void FootstepEvent(int clip)
    {
        AudioManager.Instance.PlayFootstepSound(_footsteps, clip);
        Debug.Log("Clip: " + clip);
    }

    void DisablePlayerMovement()
    {
        canMove = false;

        if (onPauseGame != null)
        {
            onPauseGame();
        }        
    }

    void ReenablePlayerMovement()
    {
        canMove = true;

        if (onResumeGame != null)
        {
            onResumeGame();
        }
    }

    void OnDisable()
    {
        UIManager.onResumeButtonClicked -= ReenablePlayerMovement;
    }
}
