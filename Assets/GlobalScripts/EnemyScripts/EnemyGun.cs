using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private EnemyController enemyController;
    private float shootRange;
    private bool canShoot;
    public GameObject enemyBullet;
    [HideInInspector]
    public Vector3 direction;
    public float bulletSpeed;
    public float reloadTime;
    void Start()
    {
        enemyController = transform.parent.parent.GetComponent<EnemyController>();
        shootRange = enemyController.shootRange;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        direction = -(transform.position - enemyController.player.position).normalized;
        if((enemyController.transform.position - enemyController.player.position).magnitude <= shootRange && canShoot)
        {
           Shoot(direction);
           canShoot = false;
           Invoke("SetShootBool",reloadTime);
        }
    }

    void Shoot(Vector3 direction)
    {
      GameObject bullet = Instantiate(enemyBullet,transform.position,Quaternion.identity,transform.parent.parent.parent);
    }

    void SetShootBool()
    {
        canShoot = true;
    }
}
