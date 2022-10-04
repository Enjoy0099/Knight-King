using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private Transform bulletSpawnPoint;

    [SerializeField]
    private float minShootTime = 2f, maxShootTime = 5f;

    private void Awake()
    {
        bulletSpawnPoint = transform.GetChild(0).transform;
    }

    private void Start()
    {
        Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
        //StartCoroutine(StartShooting());
    }

    void ShootBullet()
    {
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
    }

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(Random.Range(minShootTime, maxShootTime));
        ShootBullet(); 
        StartCoroutine(StartShooting());
    }









}
