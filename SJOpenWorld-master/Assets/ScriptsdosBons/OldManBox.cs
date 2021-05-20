using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldManBox : MonoBehaviour
{

    public Image ChatBox;
    public Text textVelho;
    public bool CanInteract = false;
    public GameObject mapObject;
    public GameObject playerChar;
    // Start is called before the first frame update
    void Start()
    {
        textVelho.enabled = false;
        ChatBox.enabled = false;
        mapObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e") && (CanInteract == true))
        {
            if ((ChatBox.enabled == false))
            {
                ChatBox.enabled = true;
                Debug.Log("Aparece");
                playerChar.GetComponent<TrdControl>().enabled = false;
                textVelho.enabled = true;

            }

            else
            {
                ChatBox.enabled = false;
                Debug.Log("Desaparece");
                playerChar.GetComponent<TrdControl>().enabled = true;
                textVelho.enabled = false;
                mapObject.SetActive(true);
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
