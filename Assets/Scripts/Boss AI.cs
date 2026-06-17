using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BossAI : EnemyStatus
{
    private static GameObject boss;

    public Transform player;
    public LayerMask whatIsPlayer;
    private float direction;
    private float bounceScale;

    public float rushDuration;
    private bool inRush;
    private float rushStart;
    private float velocityBeforeRush;

    public float cooldown; //cooldown time between special attack
    private bool ready; //ready to use special attack
    private float lastAttckTime;

    // Start is called before the first frame update
    private void Start()
    {
        direction = 1f;
        bounceScale = 1f;

        boss = gameObject;
        boss.SetActive(false);
        currentHealth = maxHealth;

        try
        {
            FireTrail.TurnOff();
        }
        catch (System.Exception) { }

        player = GameObject.Find("Player").transform;

        inRush = false;

        ready = false;
        lastAttckTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        EnvironmentLight.TurnOff(); //blinds the environment
        DeathCheck();
        transform.LookAt(player);
        transform.position += base.moveSpeed * bounceScale * direction * Time.deltaTime * transform.forward;
        Ability();
        MoreUpdate();
    }

    private void MoreUpdate() 
    {
        if (!ready && Time.time - lastAttckTime >= cooldown)
        {
            ready = true;
        }
        if (gameObject.name == "Enemy Knight" && inRush && Time.time - rushStart >= rushDuration)
        {
            FireTrail.TurnOff(); //turn off VFX
            inRush = false;
            base.moveSpeed = velocityBeforeRush;
        }
    }

    private void Ability() 
    {
        if (ready)
        {
            if (gameObject.name == "Enemy Knight")
            {
                try
                {
                    FireTrail.TurnOn(); //turn on VFX
                }
                catch (System.Exception) { }
                inRush = true;
                rushStart = Time.time;
                velocityBeforeRush = base.moveSpeed;
                base.moveSpeed *= 1.6f;
            }
            else if (gameObject.name == "Enemy Bishop")
            {
                EntityGlobal.PlayerHurt(1); //deal 1 damage regardless every few seconds
            }

            ready = false;
            lastAttckTime = Time.time;
        }

    }

    private void OnTriggerEnter(Collider other) //do damage, take damage, bounce off when successfully attacked player
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            EntityGlobal.PlayerHurt(1); //deal 1 true damage
            direction = -1f;
            bounceScale = 30f;
            base.EnemyHurt(EntityGlobal.damage); //take damage
        }
    }

    private void OnTriggerExit(Collider other) //reset the bounce back
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            direction = 1f;
            bounceScale = 1f;
        }
    }

    private void DeathCheck()
    {
        if (getCurrentHealth() <= 0)
        {
            try
            {
                EnvironmentLight.TurnOn();
            }
            catch (System.Exception) { }
            EntityGlobal.spawnMinion = true;
            Destroy(gameObject);
        }
    }
}
