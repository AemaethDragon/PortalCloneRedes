using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    #region variables
    public PlayerController playerController;
    public GameObject portalLeft;
    public GameObject portalRight;
    public GameObject portalLeftClone;
    public GameObject portalRightClone;
    public GameObject _mainCamera;

    private bool portalLeftActive = true;
    private bool portalRightActive = true;

    Ray _bullet;
    RaycastHit _hit;

    #endregion

    #region methods

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (portalLeftActive)
            {
                portalLeftClone = Instantiate(portalLeft, new Vector3(0, 0, 0), Quaternion.identity);
                ActivatePortal(portalLeftClone);
                portalLeftActive = false;
            }
            else
            {
                MovePortal(portalLeftClone);
            }
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (portalRightActive)
            {
                portalRightClone = Instantiate(portalRight, new Vector3(0, 0, 0), Quaternion.identity);
                ActivatePortal(portalRightClone);
                portalRightActive = false;
            }
            else
            {
                MovePortal(portalRightClone);
            }
        }
    }

    void ActivatePortal(GameObject portal)
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        _bullet = _mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

        if (Physics.Raycast(_bullet, out _hit))
        {
            portal.transform.position = _hit.point;
            portal.transform.rotation = Quaternion.LookRotation(_hit.normal);
        }
    }
    
    void MovePortal(GameObject portal)
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        _bullet = _mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

        if (Physics.Raycast(_bullet, out _hit))
        {

            Creatable c = _hit.collider.GetComponent<Creatable>();
            if (c != null)
            {
                portal.transform.position = _hit.point;
                portal.transform.rotation = Quaternion.LookRotation(_hit.normal);
            }
            
        }
    }

    #endregion
}
