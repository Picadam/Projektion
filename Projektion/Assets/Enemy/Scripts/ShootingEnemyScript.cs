using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShootingEnemyScript : EnemyScript
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float shootRate;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (canShoot)
        {
            canShoot = false;
            Shoot();
        } */
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.LookRotation(shootingPoint.forward));
        bullet.GetComponent<Rigidbody>().AddForce(shootingPoint.forward * bulletForce);
        bullet.transform.Rotate(90, 0, 0);
        //await Task.Delay((int)(shootRate * 1000));
        canShoot = true;

    }
}
