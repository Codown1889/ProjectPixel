using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss1;
    public GameObject boss2;

    public GameObject knightCG;
    public GameObject bishopCG;    

    public Camera CG_Camera;
    public Camera MainCamera;

    private static GameObject knight;
    private static GameObject bishop;

    private static GameObject[] bossesCG;
    private static Camera[] Cameras;

    private static MonoBehaviour instance;

    private void Start()
    {
        knight = boss1;
        bishop = boss2;

        knightCG.SetActive(false);
        bishopCG.SetActive(false);
        CG_Camera.enabled = false;

        bossesCG = new GameObject[] { knightCG, bishopCG };
        Cameras = new Camera[] { MainCamera, CG_Camera };

        instance = this;
    }

    public static void SpawnBoss()
    {
        try
        {
            knight.SetActive(true);
            instance.StartCoroutine(PlayCG(0, 15));
        }
        catch (MissingReferenceException) 
        { 
            bishop.SetActive(true);
            instance.StartCoroutine(PlayCG(1, 13));
        }
    }

    public static IEnumerator PlayCG(int index, int waitTime)
    {
        Time.timeScale = 0f;
        bossesCG[index].SetActive(true);
        Cameras[0].enabled = (false); //turn off game camera
        Cameras[1].enabled = (true); //turn on CG camera
        yield return new WaitForSecondsRealtime(waitTime);
        Cameras[0].enabled = (true); //turn on game camera
        Cameras[1].enabled = (false); //turn off CG camera
        Time.timeScale = 1f;
        bossesCG[index].SetActive(false);
    }
}