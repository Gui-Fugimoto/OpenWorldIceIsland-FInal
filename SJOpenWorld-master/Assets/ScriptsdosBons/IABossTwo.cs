using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IABossTwo : MonoBehaviour
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
    public float distancetotrigger = 30;
    public float distancetoattack = 7;
    public float distancetobreath = 25;
    public float distancetopursuitIN = 10;
    public enum States
    {
        pursuit,
        atacking,
        stoped,
        dead,
        damage,
        patrol,
        breath,
        runback,
    }

    public States state;

    // Start is called before the first frame update
    void Start()
    {
        patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
        agent.speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        anim.SetFloat("Walk_Cycle_1", agent.velocity.magnitude);

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
            case States.runback:
                RunbackState();
                break;
        }
    }

    void ReturnPursuit()
    {
        state = States.runback;

    }

    public void Damage()
    {
        state = States.damage;
        Invoke("ReturnPursuit", 0.1f);
        StartCoroutine(ReturnDamage());
    }
    IEnumerator ReturnDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            render.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.005f);
            render.material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.005f);
        }

    }

    public void Dead()
    {
        state = States.dead;
    }


    void PursuitState()
    {
        agent.speed = 9;
        agent.isStopped = false;
        agent.destination = target.transform.position;
        anim.SetBool("Breath", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Damage", false);
        if ((Vector3.Distance(transform.position, target.transform.position) < distancetobreath) && (Vector3.Distance(transform.position, target.transform.position) > distancetopursuitIN))
        {
            state = States.breath;
            Debug.Log("Breath");
        }
        if (Vector3.Distance(transform.position, target.transform.position) > distancetotrigger)
        {
            state = States.patrol;
        }
       // if (Vector3.Distance(transform.position, target.transform.position) < distancetoattack)
      //  {
       //     state = States.atacking;
       // }
    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", true);
        anim.SetBool("Damage", false);
       // if (Vector3.Distance(transform.position, target.transform.position) > distancetoattack)
       // {
      //      state = States.runback;
            //state = States.pursuit;
      //  }
    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Breath", false);
        anim.SetBool("Damage", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Dead", true);
        anim.SetBool("Damage", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        anim.SetBool("Damage", true);
    }

    void PatrolState()
    {
        agent.isStopped = false;
        agent.SetDestination(patrolposition);
        anim.SetBool("Breath", false);
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
        if ((Vector3.Distance(transform.position, target.transform.position) < distancetotrigger) && (Vector3.Distance(transform.position, target.transform.position) > distancetopursuitIN))
        {
            state = States.pursuit;
        }
        if ((Vector3.Distance(transform.position, target.transform.position) < distancetotrigger) && (Vector3.Distance(transform.position, target.transform.position) < distancetopursuitIN))
        {
            state = States.runback;
        }
    }
    void BreathState()
    {
        agent.speed = 1;
        agent.isStopped = false;
        anim.SetBool("Breath", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Damage", false);
        agent.destination = target.transform.position;
        StartCoroutine(BreathRecharge());
        if (Vector3.Distance(transform.position, target.transform.position) < distancetopursuitIN)
        {
            state = States.runback;
        }
        if (Vector3.Distance(transform.position, target.transform.position) > distancetobreath)
        {
            state = States.pursuit;
        }

    }
    IEnumerator BreathRecharge()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem go = Instantiate(breathWeapon, gameObject.transform.position + gameObject.transform.forward * 2, gameObject.transform.rotation);
        go.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 20;
        Destroy(go.gameObject, 3f);
        yield return new WaitForSeconds(10f);
    }
    void RunbackState()
    {
        agent.speed = 9;
        agent.isStopped = false;
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
        Vector3 runTo = transform.position + transform.forward * 2;
        agent.destination = runTo;
        anim.SetBool("Breath", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Damage", false);

        if (Vector3.Distance(transform.position, target.transform.position) > distancetopursuitIN)
        {
            state = States.breath;
        }
        

    }

}
