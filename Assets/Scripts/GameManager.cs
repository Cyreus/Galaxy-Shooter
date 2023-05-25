using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    private Animator pauseMenuAnimator;
    private void Start()
    {
        
        pauseMenuAnimator = GameObject.Find("PauseMenu").GetComponent<Animator>();
        pauseMenuAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            
            _pauseMenuPanel.SetActive(true);
            pauseMenuAnimator.SetBool("isPause", true);
            Time.timeScale = 0;
        }
    }
    public void GameOver()
    {
        _isGameOver = true;

    }
    public void Resume()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameMenu()
    {
        SceneManager.LoadScene(0);
    }
      
        
      
        
      

        
    

    
}
