using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    public GameObject stairs;
    bool isPress;



    private void Start()
    {
        isPress = false;
        stairs.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPress)
        {
            isPress = true;
            stairs.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (isPress)
        {
            isPress = false;
            stairs.SetActive(false);
        }
    }
}
