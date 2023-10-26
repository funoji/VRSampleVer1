using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    [SerializeField] Scene NextScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene.name);
    }
}
