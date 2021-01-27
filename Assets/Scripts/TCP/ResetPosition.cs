using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetPosition : MonoBehaviour
{
    public GameObject spawnPoint;
    private bool _fell; 
    private void OnCollisionEnter(Collision collision)
    {
        if (!_fell)
        {
            _fell = true;
            StartCoroutine(ResetPositionCoroutine(collision.gameObject.transform));
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (_fell)
        {
            _fell = false;
        }
    }

    public IEnumerator ResetPositionCoroutine(Transform resetPos)
    {
        resetPos = spawnPoint.transform;
        yield return new WaitForSeconds(2);
    }
}
