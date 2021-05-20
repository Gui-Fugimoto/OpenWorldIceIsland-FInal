using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABossFour : MonoBehaviour
{
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
        patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
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
        Destroy(gameObject, 4f);
    }


    void PursuitState()
    {
        agent.isStopped = false;
        agent.destination = target.transform.position;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Damage", false);
        anim.SetBool("Breath", false);
        if (Vector3.Distance(transform.position, target.transform.position) < distancetoattack)
        {
            state = States.atacking;
        }
        if (Vector3.Distance(transform.position, target.transform.position) > distancetotrigger)
        {
            state = States.patrol;
        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", true);
        anim.SetBool("Damage", false);
        anim.SetBool("Breath", false);
        if (Vector3.Distance(transform.position, target.transform.position) > distancetoattack + 1)
        {
            state = States.pursuit;
        }
    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Damage", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack_5", false);
        anim.SetBool("Dead", true);
        anim.SetBool("Damage", false);
        anim.SetBool("Breath", false);
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
        anim.SetBool("Attack_5", false);
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
        if (Vector3.Distance(transform.position, target.transform.position) < distancetotrigger)
        {
            state = States.pursuit;
        }
    }

}
