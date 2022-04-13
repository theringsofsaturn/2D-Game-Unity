using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Player's rigidbody
    [SerializeField] private float jumpForce = 5f; // Jump force
    [SerializeField] private bool isGrounded = false; // Is player on the ground?
    [SerializeField] private LayerMask groundLayer; // Layer mask for ground

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Horizontal input for left and right (x)
        float move = Input.GetAxisRaw("Horizontal");

        // If the player is on the ground and presses the spacebar, jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // 2D Raycast to check if the player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);

        if (hit.collider != null)
        {
            isGrounded = true;
        }

        // Current velocity = new velocity (horizontal input, current velocity y)
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

}
