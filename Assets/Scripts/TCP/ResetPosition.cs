using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetPosition : MonoBehaviour
{
    public GameObject spawnPoint;
    private Transform _goTo;
    private bool _fell;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (!_fell)
        {
            _fell = true;
            StartCoroutine(CoroutineResetPos(spawnPoint.transform,collision));
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (_fell)
        {
            _fell = false;
        }
    }

    IEnumerator CoroutineResetPos(Transform transform, Collision collision)
    {       
        _goTo = transform;
        collision.transform.position = new Vector3(_goTo.transform.position.x, _goTo.transform.position.y, _goTo.transform.position.z + 2);       
        yield return new WaitForSeconds(1f);
    }
}
