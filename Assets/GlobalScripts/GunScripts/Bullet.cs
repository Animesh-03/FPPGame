using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletEmitter bulletEmitter;
    private Rigidbody rb;
    private Vector3 direction;
    private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletEmitter = FindObjectOfType<BulletEmitter>();
        direction = bulletEmitter.direction.normalized;
        speed = bulletEmitter.bulletSpeed;
        rb.velocity = direction*speed;
        Destroy(gameObject,10f);
    }

    void Update()
    {
        Physics.IgnoreCollision(GetComponent<SphereCollider>(),FindObjectOfType<RBPlayerMovement>().transform.GetComponent<CapsuleCollider>());
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag != "Player")
        Destroy(gameObject);

        if(other.collider.tag == "Enemy")
        {
            Destroy(other.collider.gameObject);
        }

    }
}
