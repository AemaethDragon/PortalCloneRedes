using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public Transform destination, playerBody, playerCam;
    
    private bool _holding;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_holding)
            {
                GrabObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
            _holding = true;
        }
    }

    void GrabObject()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        transform.position = destination.position;
        transform.parent = destination.parent;
    }

    void DropObject()
    {
        transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
    }
}