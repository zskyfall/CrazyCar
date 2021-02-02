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
    private RunnerController _runnerController;
    
    //Background Movement controller
    private MoveLeft _moveLeft;
    private float maxMovingSpeedOfBackground = 40.0f;
    private float baseLevelPoint = 1000;
    
    private int startPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _runnerController = GameObject.Find("Character").GetComponent<RunnerController>();
        
        //To Change moving speed of background
        _moveLeft = GameObject.Find("Background").GetComponent<MoveLeft>();
        _moveLeft.speed = 5.0f;
        ToggleMenu(false);
        //btnRestart.onClick.AddListener(() => RestartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (_runnerController.gameOver == false)
        {
            startPoint++;
            
            //Update background moving speed after every baseLevelpoint( exp: 1000)
            if ((startPoint / baseLevelPoint > 1) && (startPoint % baseLevelPoint == 0) && _moveLeft.speed < maxMovingSpeedOfBackground)
            {
                _moveLeft.speed = _moveLeft.speed + 2;
            }
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
