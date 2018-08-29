using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 25f;
    [SerializeField]
    private float runningSpeed = 1.5f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    public LayerMask groundLayer;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        animator.SetBool("isAlive", true);
    }

    private void FixedUpdate()
    {
        if(rigidBody.velocity.x < runningSpeed)
        {
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        animator.SetBool("isGrounded", isGrounded());
    }

    private void Jump()
    {
        if(isGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private bool isGrounded()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}