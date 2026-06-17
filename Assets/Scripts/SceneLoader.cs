using UnityEngine;
using UnityEngine.SceneManagement; // Needed for Scene Management

public class SceneLoader : MonoBehaviour
{
    // Function to load the scene
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
