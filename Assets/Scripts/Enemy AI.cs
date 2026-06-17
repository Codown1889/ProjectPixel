using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : EnemyStatus
{
    private bool death;

    public Transform player;
    public LayerMask whatIsPlayer;
    private float direction;
    private float bounceScale;

    // Start is called before the first frame update
    private void Start()
    {
        direction = 1f;
        bounceScale = 1f;
        death = false;
        currentHealth = maxHealth;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        DeathCheck();
        if (gameObject.name != "Enemy Pawn")
        {
            transform.LookAt(player);
            transform.position += base.moveSpeed * bounceScale * direction * Time.deltaTime * transform.forward;
        }
    }

    private void OnTriggerEnter(Collider other) //do damage, take damage, bounce off when successfully attacked player
    {
        if (other.CompareTag("PlayerHurtBox"))
        {
            EntityGlobal.PlayerHurt(1); //deal 1 true damage
            direction = -1f;
            bounceScale = 20f;
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
        if (getCurrentHealth() <= 0 && !death)
        {
            EntityGlobal.currency += base.EXP;
            death = true;
            EntityGlobal.currentMinion--;
            Destroy(gameObject);
        }
        else if (getCurrentHealth() <= 0) //secure measure, no negative health
        {
            print("death");
            EntityGlobal.currentMinion--;
            Destroy(gameObject);
        }
        if (!EntityGlobal.spawnMinion && gameObject.name == "Enemy Pawn(Clone)")
        { 
            death = true;
            EntityGlobal.currentMinion--;
            Destroy(gameObject);
        }
    }
}
