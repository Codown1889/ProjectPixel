using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DeathCheck();
    }

    private void DeathCheck() 
    {
        if (EntityGlobal.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
