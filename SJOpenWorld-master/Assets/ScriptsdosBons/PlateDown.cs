using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDown : MonoBehaviour
{
    public Light myLight;
    public GameObject PlateOff;
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("untriggered");
            myLight.enabled = false;
            PlateOff.SetActive(true);
        }
    }
}
