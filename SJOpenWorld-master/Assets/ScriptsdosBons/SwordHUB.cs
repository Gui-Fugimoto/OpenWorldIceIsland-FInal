using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordHUB : MonoBehaviour
{
    public Image SwordImage;
    public Light LightWinLake;
    // Start is called before the first frame update
    void Start()
    {
        SwordImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightWinLake.enabled == true)
        {
            SwordImage.enabled = true;
        }
    }
}
