using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScaler : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*5f,transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y - 1f,transform.localPosition.z);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*0.2f,transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y + 1f,transform.localPosition.z);
        }
        var mousePos = Input.mousePosition;
        transform.LookAt(Camera.main.ScreenToWorldPoint( new Vector3(mousePos.x, mousePos.y, 5f)));
        transform.eulerAngles = new Vector3(360f,transform.eulerAngles.y,transform.eulerAngles.z);  

    }
}
