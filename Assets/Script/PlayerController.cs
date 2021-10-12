using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float moveSpeed = 1;
    public float jumpLength = 1;
    public int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed +
                      transform.right * Input.GetAxis("Horizontal") * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        Jump();
        
        Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        Debug.DrawRay(transform.position, transform.right*5, Color.green);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount != 0)
        {
            rb.AddForce(transform.up * jumpLength, ForceMode.Impulse);
            jumpCount -= 1;
            Debug.Log("Jump button pressed");
        }

        if (jumpCount > 1)
        {
            jumpCount = 1;
        }
    }

    private void OnCollisionEnter(Collision ground)
    {
        if (ground.collider.CompareTag("Ground"))
        {
            jumpCount += 1;
        }
    }

}
