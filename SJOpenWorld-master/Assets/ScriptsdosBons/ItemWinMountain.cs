using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemWinMountain : MonoBehaviour
{
    public static bool WinMountain;
    public Light LightWinMountain;
    public Light LightBlue;
    void Start()
    {
        LightWinMountain.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WinMountain == true)
        {
            LightWinMountain.enabled = true;
            LightBlue.enabled = false;
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pegou item");
            WinMountain = true;

        }

    }
}
