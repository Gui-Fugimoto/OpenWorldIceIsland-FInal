using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo2 : MonoBehaviour
{
    
    public bool alvotwo;
    public GameObject alvo2;
    // Start is called before the first frame update
    void Start()
    {
        alvotwo = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerProjectile"))
        {
            alvotwo = true;
            alvo2.SetActive(false);
        }
    }
}
