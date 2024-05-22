using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb;
    private bool _isGrounded = false;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _speed = 5.0f;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordSpriteRenderer;


    public int _diamond;
    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        _swordSpriteRenderer = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        Health = 4;
        Debug.Log("Player Health: " + Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 1)
        {
            return;
        }

        //Player Movement
        Movement();

        Attack();

    }

    void Attack()
    {
        if (SimpleInput.GetButtonDown("A_Button") && _isGrounded)
        {
            _playerAnimation.Attack();
        }
    }

    void Movement()
    {
        // Jump Functionality
        Jump();

        // Player Movement
        float horizontalInput = SimpleInput.GetAxisRaw("Horizontal"); //Input.GetAxisRaw("Horizontal");

        // FLipping of Player
        Flipping(horizontalInput);

        _rb.velocity = new Vector2(horizontalInput * _speed , _rb.velocity.y);
        _playerAnimation.Move(horizontalInput);
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || SimpleInput.GetButtonDown("B_Button")) && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isGrounded = false;
            _playerAnimation.Jump(true);
        }
    }

    void Flipping(float move)
    {
        if (move > 0)
        {
            _playerSpriteRenderer.flipX = false;
            _swordSpriteRenderer.flipX = false;
            _swordSpriteRenderer.flipY = false;
            Vector3 newPos = _swordSpriteRenderer.transform.localPosition;
            newPos.x = 1.01f;
            _swordSpriteRenderer.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            _playerSpriteRenderer.flipX = true;
            _swordSpriteRenderer.flipX = true;
            _swordSpriteRenderer.flipY = true;
            Vector3 newPos = _swordSpriteRenderer.transform.localPosition;
            newPos.x = -1.01f;
            _swordSpriteRenderer.transform.localPosition = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
            _playerAnimation.Jump(false);
        }
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        Debug.Log("Player Health: " + Health);
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1)
        {
            _playerAnimation.Death();
        }
    }

    public void AddGems(int amount)
    {
        _diamond += amount;
        UIManager.Instance.UpdateGemCount(_diamond);
    }
}
