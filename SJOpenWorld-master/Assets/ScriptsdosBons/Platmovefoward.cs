using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platmovefoward : MonoBehaviour
{
    bool MoveFoward;

    void Start()
    {
        MoveFoward = true;
    }

    void Update()
    {
        if (MoveFoward == true)
        {
            transform.Translate(new Vector3(0, 0, 5) * Time.deltaTime);
        }
        if (MoveFoward == false)
        {
            transform.Translate(new Vector3(0, 0, -5) * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("CtrlWallRight"))
        {
            MoveFoward = false;
        }
        if (other.gameObject.tag.Equals("CtrlWallLeft"))
        {
            MoveFoward = true;
        }
    }
}
