using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public float fireRate = 1.0f;
    public Transform weapon;
    public Transform firePoint;
    private float internalTime = 1.0f;

    private void Start()
    {
        internalTime = 1 / fireRate;
        StartAutoFire();
    }

    public void StartAutoFire()
    {
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(internalTime);
            if(weapon != null && firePoint != null)
            {
                Transform obj = Instantiate(weapon, transform);
                obj.position = firePoint.position;

                GameAudios.PlaySfx(gameObject, GameAudios.fireSfx);
            }
        }
    }
}
