using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.Rendering;
using UnityEngine.Experimental.GlobalIllumination;

public class EnvironmentLight : MonoBehaviour
{
    private static GameObject loom;

    // Start is called before the first frame update
    private void Start()
    {
        try
        {
            loom = GameObject.FindWithTag("Light");
        }catch(System.Exception) { }
    }

    public static void TurnOff() 
    {
        loom.SetActive(false);
    }

    public static void TurnOn()
    {
        loom.SetActive(true);
    }
}
