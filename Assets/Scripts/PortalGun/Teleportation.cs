using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    #region variables
    private Transform goTo;
    
    public GameObject player;
    #endregion

    #region methods
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("PortalLeft"))
        {
            Debug.Log("ENTERED");
            goTo = GameObject.FindGameObjectWithTag("PortalRight").GetComponent<Transform>();
        }
        else if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("PortalRight"))
        {
            Debug.Log("ENTERED2");
            goTo = GameObject.FindGameObjectWithTag("PortalLeft").GetComponent<Transform>();
        }
        
        if (Vector3.Distance(player.transform.position, col.transform.position) < 0.2f)
        {
            col.transform.position = new Vector3(goTo.position.x, goTo.position.y, goTo.position.z);
                               
            col.transform.Rotate(Vector3.up, 180f);
        }                
    }
    #endregion
}
