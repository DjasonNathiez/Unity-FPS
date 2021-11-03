using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bulletPrefabs;
    public Transform shootCanonT;


    public float moveSpeed = 2;
    public int runSpeed = 5;
    public int walkSpeed = 2;

    public float jumpLength = 1;
    public int jumpCount = 0;
    

    public float energyMax;
    public float energyActual;
    public float energyConsumeSpeed;
    public float energyConsumeSpeedLow;
    public float energyConsumeSpeedFast;
    public float energyRegen;
    public float energyRegenLow;
    public float energyRegenFast;
    public int energyToRun;

    public bool isRunning = false;
    public bool canRun = true;
    public bool energyReloading;

    public Slider energySlider;
    public GameObject energyFillImage;
    public AudioManager audioM;

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

        //deplacement marche
        rb.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed +
                      transform.right * Input.GetAxis("Horizontal") * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        
        Running();


        //energy
        Endurance();


        Jump();
        UIEnergy();
        
        Debug.DrawRay(transform.position, transform.forward*5, Color.red);
        Debug.DrawRay(transform.position, transform.right*5, Color.green);
    }

    private void Endurance()
    {
        //consume speed
        if (isRunning)
        {
            energyActual -= energyConsumeSpeed * Time.deltaTime;
        }

        if (!isRunning)
        {
            energyActual += energyRegen * Time.deltaTime;
        }

        if (energyActual > 100)
        {
            energyActual = energyMax;
        }

        if (energyActual <= 0)
        {
            energyActual = 0;
            canRun = false;
            energyReloading = true;
            StartCoroutine(EnduranceReload());
            
        }
        
        if (energyReloading)
        {
            Image fillColor = energyFillImage.GetComponent<Image>();
            fillColor.material.color = Color.red;
        }

        if (energyActual < energyToRun && canRun)
        {
            energyRegen = energyRegenFast;
            
            
            Image fillColor = energyFillImage.GetComponent<Image>();
            fillColor.material.color = Color.yellow;
        }
        
        if(energyActual > energyToRun)
        {
            energyRegen = energyRegenLow;
            
            Image fillColor = energyFillImage.GetComponent<Image>();
            fillColor.material.color = Color.white;
        }

    }

    IEnumerator EnduranceReload()
    {

        yield return new WaitUntil(() => energyActual >= energyToRun);
        canRun = true;
        energyReloading = false;


    }
    private void Running()
    {
        //run
        if (Input.GetButtonDown("Run") && rb.velocity.magnitude != 0 && canRun == true)
        {
            moveSpeed = runSpeed;
            isRunning = true;
            audioM.PlaySound("Player Run");

        }
            

        if (Input.GetButtonUp("Run"))
        {
            moveSpeed = walkSpeed;
            isRunning = false;
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

    void UIEnergy()
    {
        energySlider.maxValue = energyMax;
        energySlider.value = energyActual;

    }

}
