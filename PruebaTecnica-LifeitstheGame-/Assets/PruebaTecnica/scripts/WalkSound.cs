using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<CharacterController>().velocity.magnitude.ToString());
        if(Input.GetAxis("Horizontal") != 0 && GetComponent<CharacterController>().isGrounded && !audioSource.isPlaying || Input.GetAxis("Vertical") != 0 && GetComponent<CharacterController>().isGrounded && !audioSource.isPlaying)
        {
            audioSource.volume = 1;
            audioSource.Play();
        }else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            audioSource.volume = 0;
        }
    }
}
