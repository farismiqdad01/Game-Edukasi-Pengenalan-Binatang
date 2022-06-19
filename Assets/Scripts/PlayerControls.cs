using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerControls : MonoBehaviour
{
    Animator anim;
    PlayerInput input;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D col;
    [SerializeField] float moveSpeed = 5f;
    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        input.Player.Move.canceled += ctx => Move(Vector2.zero);
        input.Player.Jump.performed += ctx => Jump();
        input.Player.Jump.canceled += ctx => Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Move(input.Player.Move.ReadValue<Vector2>());
        if (rb.velocity.y < -0.1)
        {
            anim.SetBool("falling", true);
        }
        else
        {
            anim.SetBool("falling", false);
        }

    }
    void Move(Vector2 move)
    {
        if (move.x != 0)
        {
            sr.flipX = move.x < 0;
        }
        anim.SetBool("run", move.x != 0);
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
}
