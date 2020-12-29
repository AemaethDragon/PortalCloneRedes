using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform Destination;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GrabObject();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
        }
    }

    public void GrabObject()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("ObjDestiny").transform;
    }

    public void DropObject()
    {
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}