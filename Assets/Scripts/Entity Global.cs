using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGlobal : MonoBehaviour
{
    public static bool isPlayerMoving;

    [Header("Player Status")]
    public int current_health;
    public int max_health;
    public int attack_power;
    public int attack_cooldown;
    public int damage_negation;
    public int movement_speed;
    public int exp_currency;
    public int exp_level;

    public static int currentHealth;
    public static int maxHealth;
    public static int damage;
    public static int cooldown;
    public static int armor;
    public static float moveSpeed;
    public static int currency;
    public static int level;

    public static bool attackActivate;
    public static bool looming;
    public static bool spawnMinion; //minion
    public static bool spawnTerminate;
    public static int currentMinion;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = current_health;
        maxHealth = max_health;
        damage = attack_power;
        cooldown = attack_cooldown;
        armor = damage_negation;
        moveSpeed = movement_speed;
        currency = exp_currency;
        level = exp_level;

        attackActivate = false;
        spawnMinion = true;
    }

    // Update is called once per frame
    private void Update()
    {
        EnemySpawn.spawnMinion = spawnMinion;
        EnemySpawn.spawnTerminate = spawnTerminate;
        EnemySpawn.currentNum = currentMinion;
        PlayerLevelUp();
    }

    private void PlayerLevelUp()
    {
        if (currency >= maxHealth * 2)
        {
            level++;
            currency = 0;
            print("Level: " + level);
            BossSpawn.SpawnBoss();
            spawnMinion = false;
            spawnTerminate = true;
        }
    }

    public static void PlayerHurt(int damage)
    {
        if (damage <= 1)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth -= damage - armor;
        }
    }

}
