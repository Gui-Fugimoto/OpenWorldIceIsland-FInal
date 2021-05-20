using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }
}
