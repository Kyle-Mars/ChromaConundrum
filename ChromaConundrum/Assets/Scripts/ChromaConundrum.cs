using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChromaConundrum : MonoBehaviour
{
    static private ChromaConundrum S;

    public TMPro.TMP_Text TimerText;
    public TMPro.TMP_Text FinalTime;

    private float Timer;
    public static bool begin;

    void Start()
    {
        S = this;
        begin = false;
    }

    void Update()
    {
        //Begin stopwatch timer on first player movement.
        if (TimerText != null && begin)
        {
            Timer += Time.deltaTime;
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

            //Save most recent completion time.
            PlayerPrefs.SetString("LastTime", TimerText.text);

            //Restart level on R press.
            if (Input.GetKeyDown(KeyCode.R))
            {
                begin = false;
                ChangeScene(SceneManager.GetActiveScene().name);
            }
        }

        //Display most recent completion time.
        if (FinalTime != null &&  PlayerPrefs.HasKey("LastTime"))
        {
            FinalTime.text = PlayerPrefs.GetString("LastTime");
        }
    }

    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    [Tooltip("Check this box to reset the LastTime in PlaerPrefs")]
    public bool resetHighScoreNow = false;
    void onDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetString("LastTime", "00:00:00");
        }
    }
}
