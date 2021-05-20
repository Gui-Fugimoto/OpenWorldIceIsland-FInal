using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABossFive : MonoBehaviour
{
    public bool RemoveBarreira = false;
    public GameObject moeda;
    public GameObject target;
    public NavMeshAgent agent;
    public Animator anim;
    public Vector3 patrolposition;
    public SkinnedMeshRenderer render;
    bool isCreated;
    public float stoppedTime;
    public float patrolDistance = 10;
    public float timetowait = 3;
    public float distancetotrigger = 30;
    public float distancetoattack = 7;
    public GameObject escudo;
    public GameObject CrabShield;
    public GameObject RainSpwn;
    public enum States
    {
        pursuit,
        atacking,
        stoped,
        dead,
        damage,
        patrol,
    }

    public States state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        anim.SetFloat("Walk_Cycle_1", agent.velocity.magnitude);

    }
    IEnumerator TempoBarreira()
    {
        yield return new WaitForSeconds(15f);
        Destroy(escudo.gameObject);
        RemoveBarreira = true;//colocaria false
        Destroy(RainSpwn.gameObject);
    }
    void StateMachine()
    {
        switch (state)
        {
            case States.pursuit:
                PursuitState();
                break;
            case States.atacking:
                AttackState();
                break;
            case States.stoped:
                StoppedState();
                break;
            case States.dead:
                DeadState();
                for (int i = 0; i < 1; i++)// dropa somente 1 item após morrer
                {
                    if (!isCreated)
                    {
                        Instantiate(moeda, transform.position, Quaternion.identity);
                        isCreated = true;
                    }

                }
                break;
            case States.damage:
                DamageState();
                break;

            case States.patrol:
                PatrolState();
                break;
        }
    }

    void ReturnPursuit()
    {
        state = States.patrol;

    }
    public void Damage()
    {
        state = States.damage;
        Invoke("ReturnPursuit", 1);
        StartCoroutine(ReturnDamage());
    }
    IEnumerator ReturnDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            render.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
            render.material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
        }

    }

    public void Dead()
    {
        state = States.dead;
    }


    void PursuitState()
    {
        agent.isStopped = false;
        agent.destination = target.transform.position;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Damage", false);
        anim.SetBool("Ritual", false);

    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", true);
        anim.SetBool("Damage", false);
        anim.SetBool("Ritual", false);

    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Damage", false);
        anim.SetBool("Ritual", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Dead", true);
        anim.SetBool("Damage", false);
        anim.SetBool("Ritual", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        anim.SetBool("Damage", true);
    }

    void PatrolState()
    {
        agent.isStopped = true;
        agent.SetDestination(patrolposition);
        anim.SetBool("Attack_5", false);
        anim.SetBool("Ritual", true);
        //tempo parado
        patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
        if (!RemoveBarreira) 
        {
            Instantiate(RainSpwn, RainSpwn.transform.position = new Vector3(418, 80, 697) + gameObject.transform.forward * 0, RainSpwn.transform.rotation);
            escudo = Instantiate(CrabShield, gameObject.transform.position + gameObject.transform.forward * 0, gameObject.transform.rotation);
            //escudo.transform.parent = gameObject.transform;//o escudo faz parte da vida dele
            RemoveBarreira = true;
            
            StartCoroutine(TempoBarreira());
        }
    }

}
