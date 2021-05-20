using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public GameObject BotaoGreen;
    public GameObject BotaoRed;
    public GameObject platMov;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerProjectile"))
        {
            platMov.GetComponent<Platmovefoward>().enabled = true;
            BotaoGreen.SetActive(true);
            BotaoRed.SetActive(false);
        }
    }
}
