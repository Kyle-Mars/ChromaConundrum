using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChromaConundrum : MonoBehaviour
{
    public TMPro.TMP_Text TimerText;
    private float Timer;
    public static bool begin;

    void Update()
    {
        if (begin)
        {
            Timer += Time.deltaTime;
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

            if (Input.GetKeyDown(KeyCode.R))
            {
                begin = false;
                ChangeScene(SceneManager.GetActiveScene().name);
            }
        }    
    }

    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
