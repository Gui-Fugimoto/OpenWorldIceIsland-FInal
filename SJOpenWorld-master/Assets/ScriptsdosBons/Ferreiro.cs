using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ferreiro : MonoBehaviour
{

    public bool CanInteract = false;
    public Image ferreiroHUD;
    public Image Seta1;
    public Image Seta2;
    public Image Seta3;
    public GameObject playerChar;


    void Start()
    {
        ferreiroHUD.enabled = false;
        
    }

 
    void Update()
    {
        if (Input.GetKeyUp("e") && (CanInteract == true))
        {
            if ((ferreiroHUD.enabled == false))
            {
                ferreiroHUD.enabled = true;
                Seta1.enabled = true;
                Debug.Log("Aparece");
                playerChar.GetComponent<TrdControl>().enabled = false;
            }
            else 
            {
                ferreiroHUD.enabled = false;
                Debug.Log("Aparece");
                playerChar.GetComponent<TrdControl>().enabled = true;
                Seta1.enabled = false;
                Seta2.enabled = false;
                Seta3.enabled = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanInteract = true;
            Debug.Log("vai maninho fala com ele");
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanInteract = false;
            Debug.Log("nao fale!");
        }
    }
}
