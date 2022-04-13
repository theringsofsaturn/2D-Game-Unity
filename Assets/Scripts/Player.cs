using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Player's rigidbody
    [SerializeField] private float jumpForce = 5f; // Jump force
    [SerializeField] private bool isGrounded = false; // Is player on the ground?

    // Start is called before the first frame update
    void Start()
    {
        //*  Assign the Rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //*  Horizontal input for left and right (x)
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //*  Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //*  Current velocity = new velocity (horizontal input, current velocity y)
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

}
