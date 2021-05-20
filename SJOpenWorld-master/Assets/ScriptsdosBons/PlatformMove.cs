using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    bool MoveRight;

    void Start()
    {
        MoveRight = true;
    }

    void Update()
    {
        if (MoveRight == true)
        {
            transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);
        }
        if (MoveRight == false)
        {
            transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("CtrlWallRight"))
        {
            MoveRight = false;
        }
        if (other.gameObject.tag.Equals("CtrlWallLeft"))
        {
            MoveRight = true;
        }
    }
}
