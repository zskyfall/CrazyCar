using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public Text txtScore;
    public Text txtGameOver;
    public Button btnRestart;
    public Button btnGoHome;
    public RunnerController _runnerController;
    private int startPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _runnerController = GameObject.Find("Character").GetComponent<RunnerController>();
        ToggleMenu(false);
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
            ToggleMenu(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }

    private void ToggleMenu(bool isActive)
    {
        txtGameOver.gameObject.SetActive(isActive);
        btnRestart.gameObject.SetActive(isActive);
        btnGoHome.gameObject.SetActive(isActive);
    }
}
