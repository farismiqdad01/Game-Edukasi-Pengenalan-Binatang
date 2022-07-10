using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerControls : MonoBehaviour
{
    //referensi component player
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


    void Start()
    {
        // mengambil component yang diperlukan
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        //fungsi input system
        input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        input.Player.Move.canceled += ctx => Move(Vector2.zero);
        input.Player.Jump.performed += ctx => Jump(true);
        input.Player.Jump.canceled += ctx => Jump(false);
    }

    void Update()
    {
        // mengubah animasi berdasarkan input
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

    /// <summary>
    /// fungsi untuk menggerakkan player secara horizontal berdasarkan input
    /// </summary>
    void Move(Vector2 move)
    {
        if (move.x != 0)
        {
            sr.flipX = move.x < 0;
        }
        anim.SetBool("run", move.x != 0);
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
    }
    /// <summary>
    /// fungsi digunakan untuk melompat pada player
    /// fungsi ini berjalan jika player menekan tombol jump dan menyentuh layer ground
    /// </summary>
    public void Jump(bool jump = true)
    {
        if (IsGrounded() && jump)
        {
            rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
            AudioManager.instance.PlayerJump();
        }
    }

    /// <summary>fungsi ini untuk mendeteksi player sedang bersentuhan dengan Ground
    /// size diatur agar tidak double jump ketika mepet tembok
    /// </summary>
    private bool IsGrounded()
    {
        Vector2 size = new Vector2(col.bounds.size.x / 5, col.bounds.size.y);
        return Physics2D.BoxCast(col.bounds.center, size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
}
