using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public static PlayerController instance;

    [SerializeField]
    private float jumpForce = 25f;
    [SerializeField]
    private float runningSpeed = 1.5f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector3 playerStartingPosition;
    

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = playerStartingPosition;
    }

    private void Awake()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerStartingPosition = this.transform.position;
    }


    private void FixedUpdate()
    {
        if(GameManager.instance.currentGameState == GameState.inGame)
        {
            if(rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
    }

    private void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", isGrounded());
        }
        
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
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