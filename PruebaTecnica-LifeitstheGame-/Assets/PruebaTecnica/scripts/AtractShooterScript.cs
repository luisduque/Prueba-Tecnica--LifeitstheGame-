using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractShooterScript : MonoBehaviour
{
    public Camera cam;
    public GameObject projectilePrefab;
    public Transform firePointWeapon;

    public AttractWeapon weapon;
    public float projectileSpeed = 30;
    public float projectileMaxDistance = 50;
    public float projectileLifeTime = 100;
    public float projectileAttractorForce = 3000;

    public Vector3 destination;

    private void Start()
    {
        projectileSpeed = weapon.projectileSpeed;
        projectileMaxDistance = weapon.projectileMaxDistance;
        projectileLifeTime = weapon.projectileLifeTime;
        projectileAttractorForce = weapon.projectileAttractorForce;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, projectileMaxDistance))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(projectileMaxDistance);
        }

        InstantiateProjectile();
    }

    void InstantiateProjectile()
    {
        GameObject projectileObj = Instantiate(projectilePrefab, firePointWeapon.position, Quaternion.identity) as GameObject;
        //projectileObj.GetComponent<Rigidbody>().velocity = firePointWeapon.transform.forward * projectileSpeed;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePointWeapon.position).normalized * projectileSpeed;
        projectileObj.GetComponent<ProjectileLifeTime>().setMaxDistance(projectileMaxDistance);
        projectileObj.GetComponent<ProjectileLifeTime>().setProjectileLifeTime(projectileLifeTime);
        projectileObj.GetComponent<ProjectileLifeTime>().setAttractorForce(projectileAttractorForce);

    }

}
