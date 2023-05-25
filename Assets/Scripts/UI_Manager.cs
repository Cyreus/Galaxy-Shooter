using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _LivesImgs;
    [SerializeField]
    private Text _gameOvertext;
    [SerializeField]
    private Text _restartText;

    private GameManager _gameManager;


    


    


    void Start()
    {
       
        _ScoreText.text = "Score:" + 0;
       
        _gameOvertext.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    

    public void UpdateScore(int playerScore)
    {

        _ScoreText.text = "Score:" + playerScore.ToString();
       
    }
    

    public void UpdateLives(int currentLives)
    {
        _LivesImgs.sprite = _liveSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }
    public void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOvertext.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(gameOverFlickerRoutine());

    }

    IEnumerator gameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOvertext.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOvertext.text = " ";
            yield return new WaitForSeconds(0.5f);

        }
    }


    
}
