using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private float lastAttackTime;
    private bool inCooldown;

    private float attackStart;
    public GameObject boom;

    // Start is called before the first frame update
    private void Start()
    {
        inCooldown = false;
        boom.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!inCooldown && Input.GetKey(KeyCode.Space))
        {
            boom.SetActive(true);
            EntityGlobal.attackActivate = true;
            inCooldown = true;
            lastAttackTime = Time.time;
            attackStart = Time.time;
        }
        MoreUpdate();
    }

    private void MoreUpdate()
    {
        if (inCooldown) 
        {
            Cooldown();
        }
        if (Time.time - attackStart >= 0.02 && EntityGlobal.attackActivate)
        {
            EntityGlobal.attackActivate = false;
            StartCoroutine(waitForBoom());
        }
    }

    private IEnumerator waitForBoom()
    {
        yield return new WaitForSeconds(1);
        boom.SetActive(false);
    }

    private void Cooldown()
    {
        if (Time.time - lastAttackTime >= EntityGlobal.cooldown)
        {
            inCooldown = false;
        }
    }
}
