using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 1;
    public float jumpLength = 1;
    
    
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

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0,jumpLength,0);
        }

        Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        Debug.DrawRay(transform.position, transform.right*5, Color.green);
    }
}
