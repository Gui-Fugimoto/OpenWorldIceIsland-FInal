using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public GameObject BotaoGreen;
    public GameObject BotaoRed;
    public GameObject platMov;
    private void Start()
    {
        
        BotaoRed.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerProjectile"))
        {
            platMov.GetComponent<Platmovefoward>().enabled = false;
            BotaoGreen.SetActive(false);
            BotaoRed.SetActive(true);
        }
    }
}
