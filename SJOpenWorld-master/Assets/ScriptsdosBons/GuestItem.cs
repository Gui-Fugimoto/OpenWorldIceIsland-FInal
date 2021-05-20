using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestItem : MonoBehaviour
{
    AudioSource musica;
    private bool playSong = false;
    // Start is called before the first frame update
    void Start()
    {
        musica = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSong == true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 180);
        }
               
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Alaude"))
        {
            other.gameObject.SendMessage("ItemCollected");
            musica.Play(); 
            playSong = true;
            Destroy(gameObject, 49f);
            
            //Debug.Log("player pegou item");
        }
    }
}
