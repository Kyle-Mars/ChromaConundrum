using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
