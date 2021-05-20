using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorHUD : MonoBehaviour
{
    public Image ArmorImage;
    public Light LightWinMountain;
    // Start is called before the first frame update
    void Start()
    {
        ArmorImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightWinMountain.enabled == true)
        {
            ArmorImage.enabled = true;
        }
    }
}
