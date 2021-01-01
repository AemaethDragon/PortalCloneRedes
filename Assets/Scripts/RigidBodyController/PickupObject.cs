using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private GameObject _mainCamera;
    private bool _holding;
    private GameObject _holdingObject;
    
    public float distance;
    public float smoothing;
    
    Ray _pickObject;
    RaycastHit _hit;
    void Start()
    {
        _mainCamera = GameObject.FindWithTag("MainCamera");
    }
    
    void Update()
    {
        if (!_holding)
        {
            GrabObject();
        }
        else
        {
            HoldingObject();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        _holdingObject.GetComponent<Rigidbody>().useGravity = true;
        _holdingObject.GetComponent<Rigidbody>().freezeRotation = false;
        _holdingObject = null;
        _holding = false;
    }

    void HoldingObject()
    {
        _holdingObject.GetComponent<Rigidbody>().useGravity = false;
        _holdingObject.GetComponent<Rigidbody>().freezeRotation = true;
        _holdingObject.transform.position =
            Vector3.Lerp(_holdingObject.transform.position,
                _mainCamera.transform.position + _mainCamera.transform.forward * distance, 
                Time.deltaTime * smoothing);
    }

    void GrabObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            _pickObject = _mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            if (Physics.Raycast(_pickObject, out _hit))
            {
                Pickupable p = _hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    _holding = true;
                    _holdingObject = p.gameObject;
                }
            }
        }
    }
}
