using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IADamageBoss : MonoBehaviour
{
    public int lives = 50;
    public IABossOne IABoss1;
    public IABossTwo IABoss2;
    public IABossThree IABoss3;
    public IABossFour IABoss4;
    public IABossFive IABoss5;
    // Start is called before the first frame update
    void Start()
    {
        IABoss1.enabled = true;
        IABoss2.enabled = false;
        IABoss3.enabled = false;
        IABoss4.enabled = false;
        IABoss5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lives < 40) && (lives >= 30))
        {
            IABoss1.enabled = false;
            IABoss2.enabled = true;
            
        }
        if ((lives < 30) && (lives >= 20))
        {
            IABoss2.enabled = false;
            IABoss3.enabled = true;

        }
        if ((lives < 20) && (lives >= 10))
        {
            IABoss3.enabled = false;
            IABoss4.enabled = true;

        }
        if ((lives < 10) && (lives >= 8))
        {

            IABoss4.enabled = false;
            IABoss5.enabled = true;
        }
        if ((lives < 8) && (lives >= 0))
        {

            IABoss4.enabled = true;
            IABoss5.enabled = false;
        }
        else if (lives <= 0)
        {
            IABoss4.Dead();
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            lives--;
            IABoss1.Damage();
            IABoss2.Damage();
            IABoss3.Damage();
            IABoss4.Damage();
            IABoss5.Damage();
        }
    }

    public void ExplosionDamage()
    {
        lives = -1;
    }
}
