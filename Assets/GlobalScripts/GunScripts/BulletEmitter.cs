using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    private Vector3 mousePos;
    [HideInInspector]
    public Vector3 direction;
    public GameObject bullet;
    public float recoilForce;
    public float bulletSpeed;
    private RBPlayerMovement playerScript;
    void Start()
    {
        playerScript = FindObjectOfType<RBPlayerMovement>();
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
        direction = ray.direction;
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            playerScript.rb.AddForce(-direction*recoilForce,ForceMode.Impulse);
        }
    }
    void Shoot()
    {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
