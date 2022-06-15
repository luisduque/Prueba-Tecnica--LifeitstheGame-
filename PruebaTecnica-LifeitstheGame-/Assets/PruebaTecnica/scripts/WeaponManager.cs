using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject WeaponToActivate;
    public GameObject[] WeaponsToDesactivate;
    public AudioClip equipAudio;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Player")
        {
            Debug.Log("Colisiono con " + other.name);
            foreach (GameObject weapon in WeaponsToDesactivate)
            {
                weapon.SetActive(false);
            }
            if (!WeaponToActivate.activeSelf)
            {
                WeaponToActivate.SetActive(true);
                audioSource.PlayOneShot(equipAudio);
            }
            
        }
    }
}
