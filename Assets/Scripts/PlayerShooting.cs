using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToShoot;
    public ParticleSystem muzzleFlash;

    [Header("Settings")]
    public int totalShoots;
    public float shootCooldown;

    [Header("Shooting")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float shootForce;
    public float shootUpwardForce;

    bool readyToShoot;

    private void Start()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(shootKey) && readyToShoot && totalShoots > 0)
        {
            muzzleFlash.Play();
            Shoot();
            
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToShoot, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * shootForce + transform.up * shootUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalShoots--;

        // implement throwCooldown
        Invoke(nameof(ResetShoot), shootCooldown);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}