using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject pressurePlate;

    bool isPress = false;

    private void OnTriggerEnter(Collider col)
    {
        if (!isPress)
        {
            isPress = true;
            pressurePlate.transform.position += new Vector3(0.15f, 12.26f, -6.316681f);
        }
    }
}
