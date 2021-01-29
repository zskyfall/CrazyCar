using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenuController : MonoBehaviour
{
    private bool isMuted = false;

    public Button btnSound;
    public Sprite OffSoundSprite;
    public Sprite OnSoundSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.pause = isMuted;
        if (!isMuted)
        {
            btnSound.image.sprite = OnSoundSprite;
        }
        else
        {
            btnSound.image.sprite = OffSoundSprite;
        }
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("Scene4", LoadSceneMode.Single);
    }

    public void HighScore()
    {
        
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
