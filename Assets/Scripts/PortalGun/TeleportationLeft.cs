using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationLeft : MonoBehaviour
{
    #region variables
    private Transform _goTo;
    private bool _hasCollide;

    public GameObject rightPortal;

    #endregion

    #region methods
    private void Start()
    {
        _hasCollide = false;
        rightPortal = FindObjectOfType<TeleportationRight>().gameObject;
    }

    
    

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasCollide)
        {
            _hasCollide = true;
            StartCoroutine(CoroutineGoTo(rightPortal.transform,collision));
        }
    }

    IEnumerator CoroutineGoTo(Transform transform, Collision collision)
    {
        Vector3 temp = new Vector3(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z);
        _goTo = transform;
        collision.transform.position = new Vector3(_goTo.transform.position.x, _goTo.transform.position.y, _goTo.transform.position.z + 2);
        collision.transform.Rotate(temp, 180f);
        yield return new WaitForSeconds(1f);
    }

    private void OnCollisionExit(Collision collision)
    {
        _hasCollide = false;
    }

    #endregion
}
