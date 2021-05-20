using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaoAlvo : MonoBehaviour
{
    public GameObject Alvo1;
    public GameObject Alvo2;
    public GameObject Alvo3;
    //public GameObject Cubo4;
    public GameObject portao2;

    // Start is called before the first frame update
    void Start()
    {
        portao2.SetActive(true);

    }

    void Update()
    {
        if ((Alvo1.activeSelf == false) && (Alvo2.activeSelf == false) && (Alvo3.activeSelf == false))
        {
            portao2.SetActive(false);
        }
    }
}