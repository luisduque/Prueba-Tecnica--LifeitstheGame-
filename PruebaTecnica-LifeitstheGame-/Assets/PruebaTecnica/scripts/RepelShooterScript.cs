using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;



public class RepelShooterScript : MonoBehaviour
{
    public Transform repelPos;

    public VisualEffect vfx;
    public AudioSource audioSource;

    public RepelWeapon weapon;
    private float repelRadius;
    private float repelPower;
    private float upwardsModifier;

    private void Start()
    {
        repelRadius = weapon.repelRadius;
        repelPower = weapon.repelPower;
        upwardsModifier = weapon.upwardsModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ApplyyReppelForce();
            vfx.SetFloat("Particle size", 0.05f);
            audioSource.volume = 1f;
            audioSource.pitch = 0.65f;
        }
        else
        {
            vfx.SetFloat("Particle size", 0.01f);
            audioSource.volume = 0.2f;
            audioSource.pitch = 1;
        }

    }

    void ApplyyReppelForce()
    {
        Vector3 explosionPos = repelPos.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, repelRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && hit.tag == "ToAttract")
            {
                rb.AddExplosionForce(repelPower, explosionPos, repelRadius, upwardsModifier);
                Debug.Log("Repelling " + hit.name);
            }
                

           
        }
    }
}
