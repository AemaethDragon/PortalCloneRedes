using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    public GameObject pressurePlate;
    public GameObject stairs;
    bool isPress;



    private void Start()
    {
        isPress = false;
        stairs.SetActive(false);
    }

    private void OnCollisionEnter(Collider col)
    {
        if (!isPress)
        {
            isPress = true;
            stairs.SetActive(true);
        }
    }
}
