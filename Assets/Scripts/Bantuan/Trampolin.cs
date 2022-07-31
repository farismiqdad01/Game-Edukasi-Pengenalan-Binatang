using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField] float bounceForce = 20f;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
            AudioManager.instance.PlayerJump();
            animator.Play("action");
        }
    }
}
