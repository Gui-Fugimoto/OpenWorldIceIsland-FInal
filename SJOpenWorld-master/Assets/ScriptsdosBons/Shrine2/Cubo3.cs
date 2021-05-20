using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo3 : MonoBehaviour
{
    public bool cubetres;
    public GameObject cubo3;
    // Start is called before the first frame update
    void Start()
    {
        cubetres = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("AtivarCubo"))
        {
            cubetres = true;
            cubo3.SetActive(false);
        }
    }
}
