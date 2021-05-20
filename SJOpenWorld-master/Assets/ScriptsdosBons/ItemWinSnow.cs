using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWinSnow : MonoBehaviour
{
    public static bool WinSnow;
    public Light LightWinSnow;
    public Light LightBlue;
    void Start()
    {
        LightWinSnow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WinSnow == true)
        {
            LightWinSnow.enabled = true;
            LightBlue.enabled = false;
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pegou item");
            WinSnow = true;

        }

    }
}
