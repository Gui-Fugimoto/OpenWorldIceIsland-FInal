using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlvoNPC : MonoBehaviour
{
    public Animator anim;
    public Transform[] target;
    public float speed;
    public float damping = 6.0f;

    private int current;

    void Update()
    {
        if (Vector3.Distance(target[current].position, transform.position) > 0.1f) 
        {
          //  Vector4 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target[current].position, speed* Time.deltaTime);
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            anim.SetBool("Female Walk", true);


        }
        else
        {

            current = (current + 1) % target.Length;
            Debug.Log("Chegou");
            anim.SetBool("Female Walk", false);
        }
    }

}
