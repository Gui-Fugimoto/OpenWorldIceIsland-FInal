using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaHUD : MonoBehaviour
{
    public Image BolaImage;
    public Light LightWinRuin;
    // Start is called before the first frame update
    void Start()
    {
        BolaImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightWinRuin.enabled == true)
        {
            BolaImage.enabled = true;
        }
    }
}
