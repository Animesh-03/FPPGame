using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPMouseLook : MonoBehaviour
{
    public Transform player;
   // public Transform gun;
    public float mouseSensitivity;
    private float xRotation;
    private Vector3 initGunRot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       // initGunRot = gun.transform.localEulerAngles;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY  = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //gun.transform.localEulerAngles = transform.localEulerAngles + initGunRot;
        //gun.transform.eulerAngles = transform.localEulerAngles + initGunRot;

        player.Rotate(Vector3.up*mouseX);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localPosition -= Vector3.up; 
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localPosition += Vector3.up; 
        }

    }
}
