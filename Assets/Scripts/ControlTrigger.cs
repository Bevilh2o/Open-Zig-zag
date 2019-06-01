using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col) //Gets executed every time an object leaves the trigger
    {
        if (col.gameObject.tag == "Ball")
        {
            Invoke("MakePlatformFall",0.5f); //Calls the MakePlatformFall function after 0.5 seconds
        }
    }

    void MakePlatformFall()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 2f); //Destroys the parent game object (platform) after 2 seconds
    }
}
