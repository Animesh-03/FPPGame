using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.localEulerAngles = new Vector3(-cam.transform.localEulerAngles.x + transform.localEulerAngles.x,transform.localEulerAngles.y,transform.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(270f,transform.localEulerAngles.y,transform.localEulerAngles.z);
    }
}
