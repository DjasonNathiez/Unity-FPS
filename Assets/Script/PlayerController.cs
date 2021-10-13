using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bulletPrefabs;
    public Transform shootCanonT;


    public float moveSpeed = 1;
    public int runSpeed = 3;
    public int walkSpeed = 2;

    public float jumpLength = 1;
    public int jumpCount = 0;
    

    public float energyMax;
    public float energyActual;
    public float energyConsumeSpeed;
    public float energyCD;
    public bool energyOnCD;
    public float energyUpSpeed;
    public bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = walkSpeed;
        energyActual = energyMax;
    }

    // Update is called once per frame
    void Update()
    {

        //deplacement
        rb.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed +
                      transform.right * Input.GetAxis("Horizontal") * moveSpeed + new Vector3(0, rb.velocity.y, 0);


        //run
        if (Input.GetButtonDown("Run") && rb.velocity.magnitude != 0 && energyActual != 0)
        {
            moveSpeed = runSpeed;
            isRunning = true;
            

            Debug.Log("running");
        }

        if (Input.GetButtonUp("Run"))
        {
            moveSpeed = walkSpeed;
            isRunning = false;
            Debug.Log("not running");
        }




        if(isRunning == true)
        {

            energyActual -= energyConsumeSpeed * Time.deltaTime;
        }

        if(energyActual <= 0)
        {
            energyActual = 0;
            isRunning = false;
            moveSpeed = walkSpeed;
            energyOnCD = true;
        }

        if(energyActual > energyMax)
        {
            energyActual = energyMax;
        }

        if(energyOnCD == true)
        {
            energyCD -= Time.deltaTime;
        }
       
        if(isRunning == false)
        {

            energyActual += energyUpSpeed * Time.deltaTime;
            energyOnCD = true;
        }

    
        if(energyCD <= 0)
        {
            energyCD = 5;
            energyOnCD = false;
        }



        Jump();
        
        Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        Debug.DrawRay(transform.position, transform.right*5, Color.green);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            //créer la bullet
        }
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
