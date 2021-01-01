using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    #region variables
    private Transform _goTo;
    private GameObject _tempPortal;
    #endregion

    #region methods
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("PortalLeft"))
        {
            _tempPortal = GameObject.FindGameObjectWithTag("PortalRight");
            _goTo = _tempPortal.transform;
            col.transform.position = new Vector3(_goTo.transform.position.x,
                _goTo.transform.position.y, _goTo.transform.position.z + 2);
            col.transform.Rotate(Vector3.up, 180f);
        }
        else if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("PortalRight"))
        {
            _tempPortal = GameObject.FindGameObjectWithTag("PortalLeft");
            _goTo = _tempPortal.transform;
            col.transform.position = new Vector3(_goTo.transform.position.x,
                _goTo.transform.position.y, _goTo.transform.position.z - 2);
            col.transform.Rotate(Vector3.up, 180f);
        }
    }
    #endregion
}
