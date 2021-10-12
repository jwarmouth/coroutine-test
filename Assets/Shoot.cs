using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawn;
    public Transform bulletContainer;
    public float shotCooldown;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine("ShootWithCooldown");
        }
    }

    IEnumerator ShootWithCooldown ()
    {
        // stuff before the delay
        Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation, bulletContainer);
        canShoot = false;
        Debug.Log(bulletContainer.childCount + " Bullets Shot");

        // the delay
        yield return new WaitForSeconds(shotCooldown);

        // stuff after the delay
        canShoot = true;


    }

    //IEnumerator SpawnWave()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Instantiate(bulletPrefab);
    //        yield return new WaitForSeconds(1);
    //    }
    //}


}
