using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo2 : MonoBehaviour
{
 
        public bool cubetwo;
        public GameObject cubo2;
        // Start is called before the first frame update
        void Start()
        {
            cubetwo = false;
        }

        public void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("AtivarCubo"))
            {
                cubetwo = true;
                cubo2.SetActive(false);
            }
        }
        //public void GetCubo1()



    
}
