using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo4 : MonoBehaviour
{
    public bool cubequatro;
    public GameObject cubo4;
    // Start is called before the first frame update
    void Start()
    {
        cubequatro = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("AtivarCubo"))
        {
            cubequatro = true;
            cubo4.SetActive(false);
        }
    }
}
