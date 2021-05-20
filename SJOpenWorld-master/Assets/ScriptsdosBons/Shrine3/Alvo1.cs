using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo1 : MonoBehaviour
{
    
    public bool alvoone;
    public GameObject alvo1;
    // Start is called before the first frame update
    void Start()
    {
        alvoone = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerProjectile"))
        {
            alvoone = true;
            alvo1.SetActive(false);
        }
    }
}
