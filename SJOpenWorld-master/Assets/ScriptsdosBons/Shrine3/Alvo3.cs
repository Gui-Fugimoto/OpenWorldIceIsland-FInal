using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo3 : MonoBehaviour
{
    
    public bool alvotres;
    public GameObject alvo3;
    // Start is called before the first frame update
    void Start()
    {
        alvotres = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerProjectile"))
        {
            alvotres = true;
            alvo3.SetActive(false);
        }
    }
}
