using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationRight : MonoBehaviour
{
    #region variables
    private Transform _goTo;
    public GameObject leftPortal;
    private bool _hasCollide;
    #endregion

    #region methods
    private void Start()
    {
        _hasCollide = false;
    }
    private void Update()
    {
        try
        {
            if (leftPortal == null)
            {
                leftPortal = FindObjectOfType<TeleportationLeft>().gameObject;

            }
        }
        catch (System.Exception)
        {
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasCollide)
        {
            _hasCollide = true;
            Debug.Log(_hasCollide);
            _goTo = leftPortal.transform;
            collision.transform.position = new Vector3(_goTo.transform.position.x,
                _goTo.transform.position.y, _goTo.transform.position.z + 2);
            collision.transform.Rotate(Vector3.up, 180f);

        }
        //_goTo = _tempPortalLeft.transform;
        //collision.transform.position = new Vector3(_goTo.transform.position.x,
        //        _goTo.transform.position.y, _goTo.transform.position.z - 2);
        //collision.transform.Rotate(Vector3.up, 180f);

    }
    private void OnCollisionExit(Collision collision)
    {
        if (_hasCollide)
        {
            _hasCollide = false;
        }
    }
    #endregion
}
