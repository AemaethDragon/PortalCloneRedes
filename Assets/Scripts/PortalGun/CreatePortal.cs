using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    #region variables
    public PlayerController playerController;
    
    public GameObject _mainCamera;

    Ray _bullet;
    RaycastHit _hit;

    #endregion

    #region methods

    void Update()
    {
        if (!playerController.Playable) return;
        
        if (Input.GetButtonDown("Fire1"))
        {
            MovePortal(FindObjectOfType<TeleportationLeft>().gameObject);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            MovePortal(FindObjectOfType<TeleportationRight>().gameObject);
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
