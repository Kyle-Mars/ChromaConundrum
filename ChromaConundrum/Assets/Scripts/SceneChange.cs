using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Start") ChangeScene("Start");
    }

    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
