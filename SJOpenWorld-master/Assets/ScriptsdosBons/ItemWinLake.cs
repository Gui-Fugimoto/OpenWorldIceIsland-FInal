using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWinLake : MonoBehaviour
{
    public static bool WinLake;
    public Light LightWinLake;
    public Light LightBlue;
    void Start()
    {
        LightWinLake.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WinLake == true)
        {
            LightWinLake.enabled = true;
            LightBlue.enabled = false;
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pegou item");
            WinLake = true;

        }

    }
}
