using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapinha : MonoBehaviour
{
    
    public static bool mapCheck = false;
    

    void Start()
    {
        
        if (mapCheck == true)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            mapCheck = true;
            Destroy(gameObject);
            Debug.Log("pegou mapa");
        }

    }
}
