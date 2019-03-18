using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;
    public float moveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Animator animator;

    public Vector3 respawnPosition;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        respawnPosition = transform.position;

        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Character move
        if (Input.GetAxisRaw("Horizontal") > 0f) {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (Input.GetAxisRaw("Horizontal") < 0f) {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);
        }

        // Character jump
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed, 0f);
        }

        // Apply animation
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Kills the player
        if (collision.tag == "KillPlane") {
            levelManager.Respawn();
        }

        if (collision.tag == "Checkpoint") {
            respawnPosition = collision.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Makes the player move with the moving platform
        if (collision.gameObject.tag == "MovingPlatform") {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "MovingPlatform") {
            transform.parent = null;
        }
    }
}
