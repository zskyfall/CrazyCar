using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public Text txtScore;
    public Button btnRestart;
    private RunnerController _runnerController;
    private int startPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _runnerController = GameObject.Find("Character").GetComponent<RunnerController>();
        btnRestart.gameObject.SetActive(false);
        //btnRestart.onClick.AddListener(() => RestartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (_runnerController.gameOver == false)
        {
            startPoint++;
            txtScore.text = startPoint.ToString();
        }
        else //If game is over
        {
            btnRestart.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
