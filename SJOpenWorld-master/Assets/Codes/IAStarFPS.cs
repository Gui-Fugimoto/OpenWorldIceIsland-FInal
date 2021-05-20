using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStarFPS : MonoBehaviour
{
    public GameObject moeda;
    public GameObject target;
    public NavMeshAgent agent;
    public Animator anim;
    public Vector3 patrolposition;
    public SkinnedMeshRenderer render;
    public ParticleSystem breathWeapon;
    bool isCreated;
    public float stoppedTime;
    public float patrolDistance = 10;
    public float timetowait = 3;
    public float distancetotrigger = 18;
    public float distancetoattack = 3;
    public float distancetobreath = 9;
    public float distancetopursuitIN = 7;
    public enum States
    {
        pursuit,
        atacking,
        stoped,
        dead,
        damage,
        patrol,
        breath,
    }

    public States state;

    // Start is called before the first frame update
    void Start()
    {
        patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        anim.SetFloat("Velocidade", agent.velocity.magnitude);

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
            case States.breath:
                BreathState();
                break;
        }
    }

    void ReturnPursuit()
    {
        state = States.pursuit;
       
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
        anim.SetBool("BaiacuAttack", false);
        anim.SetBool("BaiacuDeath", false);
        anim.SetBool("BaiacuBreath", false);
        if ((Vector3.Distance(transform.position, target.transform.position) < distancetobreath) && (Vector3.Distance(transform.position, target.transform.position) > distancetopursuitIN))
        {
            state = States.breath;
            Debug.Log("Breath");
        }
        if (Vector3.Distance(transform.position, target.transform.position) > distancetotrigger)
        {
            state = States.patrol;
        }
        if (Vector3.Distance(transform.position, target.transform.position) < distancetoattack)
        {
            state = States.atacking;
        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("BaiacuAttack", true);
        anim.SetBool("BaiacuDamage", false);
        anim.SetBool("BaiacuBreath", false);
        if (Vector3.Distance(transform.position, target.transform.position) > distancetoattack)
        {
            state = States.pursuit;
        }
    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.SetBool("BaiacuAttack", false);
        anim.SetBool("BaiacuDamage", false);
        anim.SetBool("BaiacuBreath", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("BaiacuAttack", false);
        anim.SetBool("BaiacuBreath", true);
        anim.SetBool("BaiacuDeath", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        anim.SetBool("BaiacuDeath", true);
    }

    void PatrolState()
    {
        agent.isStopped = false;
        agent.SetDestination(patrolposition);
        anim.SetBool("BaiacuAttack", false);
        //tempo parado
        if (agent.velocity.magnitude < 0.1f)
        {
            stoppedTime += Time.deltaTime;
        }
        //se for mais q timetowait segundos
        if (stoppedTime > timetowait)
        {
            stoppedTime = 0;
            patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
        }
        //ditancia do jogador for menor q distancetotrigger
        if (Vector3.Distance(transform.position, target.transform.position) < distancetotrigger)
        {
            state = States.pursuit;
        }
    }
    void BreathState()
    {
        agent.isStopped = true;
        anim.SetBool("BaiacuBreath", true);
        anim.SetBool("BaiacuDeath", false);

        StartCoroutine(BreathRecharge());
        if (Vector3.Distance(transform.position, target.transform.position) < distancetopursuitIN)
        {
            state = States.pursuit;
        }
        if (Vector3.Distance(transform.position, target.transform.position) > distancetobreath)
        {
            state = States.pursuit;
        }

    }
    IEnumerator BreathRecharge()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem dota = Instantiate(breathWeapon, gameObject.transform.position + gameObject.transform.forward * 2, gameObject.transform.rotation);
        dota.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 10;
        Destroy(dota.gameObject, 1f);
        yield return new WaitForSeconds(10f);
    }

}
