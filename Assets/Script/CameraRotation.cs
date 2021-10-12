using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Camera playerCam;
    private Transform transformCam;

    public float rotationSpeed = 1;
    public float lookXLimit = 75;

    private float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
        transformCam = playerCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transformCam.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
        transform.localRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
}
