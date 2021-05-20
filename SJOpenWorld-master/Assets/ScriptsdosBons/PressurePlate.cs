using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Light myLight;
    public GameObject PlateOff;
    private void Start()
    {
        myLight.enabled = false;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("triggered");
            myLight.enabled = true;
            PlateOff.SetActive(false);
        }
    }
}
