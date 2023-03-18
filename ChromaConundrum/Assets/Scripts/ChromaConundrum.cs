using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChromaConundrum : MonoBehaviour
{
    public TMPro.TMP_Text TimerText;
    public TMPro.TMP_Text FinalTime;

    private float Timer;
    public static bool begin;

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
            PlayerPrefs.SetString("BestTime", TimerText.text);

            //Restart level on R press.
            if (Input.GetKeyDown(KeyCode.R))
            {
                begin = false;
                ChangeScene(SceneManager.GetActiveScene().name);
            }
        }

        //Display most recent completion time.
        if (FinalTime != null &&  PlayerPrefs.HasKey("BestTime"))
        {
            FinalTime.text = PlayerPrefs.GetString("BestTime");
        }
    }

    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    [Tooltip("Check this box to reset the HighScore in PlaerPrefs")]
    public bool resetHighScoreNow = false;
    void onDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
