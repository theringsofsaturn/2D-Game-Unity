using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Player's rigidbody
    [SerializeField] private float jumpForce = 6.0f; // Jump force
    [SerializeField] private bool isGrounded = false; // Is player on the ground?
    [SerializeField] private LayerMask groundLayer; // Layer mask for ground
    private bool resetJumpNeeded = false; // Is player's jump reset needed?

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        CheckIfGrounded();
    }

    void Movement()
    {
        //  Horizontal input for left and right (x)
        float move = Input.GetAxisRaw("Horizontal");

        // If the player is on the ground and presses the spacebar, jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }
        // Current velocity = new velocity (horizontal input, current velocity y)
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    void CheckIfGrounded()
    {
        // 2D Raycast to check if the player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer.value);

        if (hit.collider != null)
        {
            if (resetJumpNeeded == false)
                isGrounded = true;
        }
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        resetJumpNeeded = false;
    }

}
