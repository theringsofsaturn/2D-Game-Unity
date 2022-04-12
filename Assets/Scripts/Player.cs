using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Player's rigidbody

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
        float x = Input.GetAxisRaw("Horizontal");

        //*  Current velocity = new velocity (horizontal input, current velocity y)
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

}
