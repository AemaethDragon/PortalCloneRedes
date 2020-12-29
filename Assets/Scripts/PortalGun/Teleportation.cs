using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    #region variables
    
    private Transform goTo;

    public bool isLeft;
    #endregion

    #region methods
    void Start()
    {
        if (isLeft == false)
        {
            goTo = GameObject.FindGameObjectWithTag("PortalLeft").GetComponent<Transform>();
        }
        else
        {
            goTo = GameObject.FindGameObjectWithTag("PortalRight").GetComponent<Transform>();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {       
        if (Vector3.Distance(transform.position, other.transform.position) < 0.2f)
        {
            other.transform.position = new Vector3(goTo.position.x, goTo.position.y, goTo.position.z);
                               
            other.transform.Rotate(Vector3.up, 180f);
        }                
    }
    #endregion
}
