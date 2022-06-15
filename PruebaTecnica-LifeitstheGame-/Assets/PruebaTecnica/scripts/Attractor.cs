using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject[] objectsToAttract;

    private void Start()
    {
        objectsToAttract = GameObject.FindGameObjectsWithTag("ToAttract");
    }

    private void FixedUpdate()
    {
        if(objectsToAttract != null)
        {
            foreach(GameObject obj in objectsToAttract)
            {
                if(obj.gameObject != this.gameObject)
                {
                    Attract(obj);
                }
                
            }

        }
        
    }

    void Attract (GameObject objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.GetComponent<Rigidbody>();

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }
}
