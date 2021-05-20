using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWinRuin : MonoBehaviour
{
    public static bool WinRuin;
    public Light LightWinRuin;
    public Light LightBlue;
    void Start()
    {
        LightWinRuin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WinRuin == true)
        {
            LightWinRuin.enabled = true;
            LightBlue.enabled = false;
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pegou item");
            WinRuin = true;

        }

    }
}
