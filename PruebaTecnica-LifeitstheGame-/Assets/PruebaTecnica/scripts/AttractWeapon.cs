using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Attract Weapon")]
public class AttractWeapon : ScriptableObject
{
    public float projectileSpeed;
    public float projectileMaxDistance;
    public float projectileLifeTime;
    public float projectileAttractorForce;
}
