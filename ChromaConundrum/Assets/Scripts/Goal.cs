using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string nextScene;

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneChange.ChangeScene(nextScene);
    }
}
