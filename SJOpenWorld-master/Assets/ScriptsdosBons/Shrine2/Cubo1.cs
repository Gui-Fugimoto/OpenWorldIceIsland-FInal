using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo1 : MonoBehaviour
{
        public bool cubeone;
        public GameObject cubo1;
        // Start is called before the first frame update
        void Start()
        {
            cubeone = false;
        }

        public void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("AtivarCubo"))
            {
                cubeone = true;
                cubo1.SetActive(false);
            }
        }
        


    
}
