using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUseMap : MonoBehaviour
{
    public Image mapImage;
    public static bool mapCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        mapImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("m") && (mapCollected == true))
        {
            if (mapImage.enabled == false)
            {
                mapImage.enabled = true;
                Debug.Log("DotA");
            }
            else
            {
                mapImage.enabled = false;
                Debug.Log("DotA 2");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("MapObject"))
        {
            mapCollected = true;
            Debug.Log("colidiu");
        }
    }
}
