using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Repel Weapon")]
public class RepelWeapon : ScriptableObject
{
    public float repelRadius;
    public float repelPower;
    public float upwardsModifier;

}
