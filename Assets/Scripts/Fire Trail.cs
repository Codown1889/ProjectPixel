using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrail : MonoBehaviour
{
    private static GameObject trail;

    // Start is called before the first frame update
    private void Start()
    {
        try
        {
            trail = GameObject.FindWithTag("Trail");
        }
        catch (System.Exception) { }
    }

    public static void TurnOff()
    {
        trail.SetActive(false);
    }

    public static void TurnOn()
    {
        trail.SetActive(true);
    }
}
