using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Parabolic Weapon")]
public class ParabolicWeapon : ScriptableObject
{
    public float projectileSpeed;
    public float projectileMass;
    public bool destroyProjectileOnCollision;
    public float proctileLifeTime;
}
