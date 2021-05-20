using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivroHUD : MonoBehaviour
{
    public Image LivroImage;
    public Light LightWinLivro;
    // Start is called before the first frame update
    void Start()
    {
        LivroImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightWinLivro.enabled == true)
        {
            LivroImage.enabled = true;
        }
    }
}
