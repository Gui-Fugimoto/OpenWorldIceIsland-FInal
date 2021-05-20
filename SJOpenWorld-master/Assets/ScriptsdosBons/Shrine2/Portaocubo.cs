using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portaocubo : MonoBehaviour
{
    public GameObject Cubo1;
    public GameObject Cubo2;
    public GameObject Cubo3;
    public GameObject Cubo4;
    public GameObject portao;

    // Start is called before the first frame update
    void Start()
    {
        portao.SetActive(true);
       
    }

    void Update()
    {
        if ((Cubo1.activeSelf == false) && (Cubo2.activeSelf == false) && (Cubo3.activeSelf == false) && (Cubo4.activeSelf == false))
        {
            portao.SetActive(false);
        }
    }
}
