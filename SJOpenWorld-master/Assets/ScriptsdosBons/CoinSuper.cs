using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSuper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ScoreTextScript.coinAmount += 50;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
    }
}

