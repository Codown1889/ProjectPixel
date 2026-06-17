using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Status")]
    public int currentHealth;
    public int maxHealth;
    public int damage;
    public int armor;
    public float moveSpeed;
    public int EXP;

    [Header("Movement")]
    public float groundDrag;
    public Transform orientation;

    public Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        SpeedControl();
        rb.drag = groundDrag;
    }

    public void EnemyHurt(int damage)
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

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnTriggerStay(Collider other) //been attacked by player's hitbox
    {
        if (other.CompareTag("PlayerHitBox") && EntityGlobal.attackActivate)
        {
            EnemyHurt(EntityGlobal.damage); //take damage
        }
    }

    public int getCurrentHealth() 
    {
        return currentHealth;
    }

    public void setCurrentHealth(int health)
    {
        currentHealth = health;
    }

}
