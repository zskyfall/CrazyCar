using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour
{
    public TMP_Text txtHighScore1;
    public TMP_Text txtHighScore2;
    public TMP_Text txtHighScore3;
    // Start is called before the first frame update
    void Start()
    {
        //int highScore = PlayerPrefs.GetInt("high_score", 0);
        int[] scores = PlayerPrefsX.GetIntArray("scores");
        
        if (scores.Length >= 3)
        {
            txtHighScore1.SetText(scores[scores.Length - 1].ToString());
            txtHighScore2.SetText(scores[scores.Length - 2].ToString());
            txtHighScore3.SetText(scores[scores.Length - 3].ToString());
        }
        if (scores.Length == 2)
        {
            txtHighScore1.SetText(scores[scores.Length - 1].ToString());
            txtHighScore2.SetText(scores[scores.Length - 2].ToString());
            txtHighScore3.SetText("");
        }
        if (scores.Length == 1)
        {
            txtHighScore1.SetText(scores[scores.Length - 1].ToString());
            txtHighScore2.SetText("");
            txtHighScore3.SetText("");
        }
        if (scores.Length == 0)
        {
            txtHighScore1.SetText("");
            txtHighScore2.SetText("");
            txtHighScore3.SetText("");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GoHome()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
