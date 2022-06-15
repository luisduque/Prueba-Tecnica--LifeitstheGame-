using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShooterScript : MonoBehaviour
{
    public Camera cam;
    public GameObject projectilePrefab;
    public GameObject projectileSimulationPrefab;
    public Transform firePointWeapon;


    public ParabolicWeapon weapon;
    public float projectileSpeed;
    public float projectileMass;
    public float projectileLifeTime;
    public bool destroyProjectileOnCollision;

    public Vector3 destination;

    [SerializeField] private ParabolicScript parabolic;

    private void Start()
    {
        projectileSpeed = weapon.projectileSpeed;
        projectileMass = weapon.projectileMass;
        projectileLifeTime = weapon.proctileLifeTime;
        destroyProjectileOnCollision = weapon.destroyProjectileOnCollision;

    }

    // Update is called once per frame
    void Update()
    {
        parabolic.SimulateTrajectory(projectileSimulationPrefab, firePointWeapon.position, firePointWeapon.forward);
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile();
    }

    void InstantiateProjectile()
    {
        GameObject projectileObj = Instantiate(projectilePrefab, firePointWeapon.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = firePointWeapon.transform.forward * projectileSpeed;
        projectileObj.GetComponent<Rigidbody>().mass = projectileMass;
        projectileObj.GetComponent<ParabolicProjectileLifetime>().destroyOnCollision = destroyProjectileOnCollision;
        projectileObj.GetComponent<ParabolicProjectileLifetime>().isSimulation = false;
        projectileObj.GetComponent<ParabolicProjectileLifetime>().secondsToDestroy = projectileLifeTime;
    }
}
