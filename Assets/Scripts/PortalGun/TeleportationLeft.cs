using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationLeft : MonoBehaviour
{
    #region variables
    private Transform _goTo;
    //public CreatePortal createPortal;
    public GameObject rigthPortal;
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
            if (rigthPortal == null)
            {
                rigthPortal = FindObjectOfType<TeleportationRight>().gameObject;

            }
        }
        catch (System.Exception)
        {
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        //_goTo = createPortal.portalRightClone.transform;
        //collision.transform.position = new Vector3(_goTo.transform.position.x,
        //    _goTo.transform.position.y, _goTo.transform.position.z + 2);
        //collision.transform.Rotate(Vector3.up, 180f);


        if (!_hasCollide)
        {
            _hasCollide = true;
            _goTo = rigthPortal.transform;
            collision.transform.position = new Vector3(_goTo.transform.position.x,
                    _goTo.transform.position.y, _goTo.transform.position.z - 2);
            collision.transform.Rotate(Vector3.up, 180f);

        }

    }
    private void OnCollisionExit(Collision collision)
    {
        _hasCollide = false;
    }
    #endregion
}
