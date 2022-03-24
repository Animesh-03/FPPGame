using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody rb;
    private EnemyGun enemyGun;
    private Vector3 direction;
    private float bulletSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyGun = transform.parent.transform.Find("EnemyMesh").transform.Find("Gun").transform.Find("BulletOrigin").GetComponent<EnemyGun>();
        direction = enemyGun.direction;
        bulletSpeed = enemyGun.bulletSpeed;
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction*bulletSpeed;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            Debug.Log("Collided with player");
        }
        Destroy(gameObject);
    }
}
