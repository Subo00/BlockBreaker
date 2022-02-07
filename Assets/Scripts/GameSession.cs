using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //configuration parameters
    [Range(0.1f,5f)][SerializeField] private float _gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _lifeText;
    [SerializeField] private int _startLife;
    [SerializeField] private int _extraLifePerScore;
    public bool isAutoPlayEnabled = false;
    //State variables
    private int _score = 0;
    private int _life;

    
    
    void Awake()
    {
        int GameSessionCount = FindObjectsOfType<GameSession>().Length;
        if(GameSessionCount > 1)
        {
            DestroyOneSelf();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
    	_life = _startLife;
        UpdateUI();
    }

    void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        if(_score % _extraLifePerScore == 0)
        _life++;

        UpdateUI();
    }

   	public void LoseLife()
   	{
   		_life--;
   		UpdateUI();
   		if(_life == 0)
   		FindObjectOfType<SceneLoader>().LoadGameOver();
   	} 



    private void UpdateUI()
    {
        _scoreText.text = "SCORE: " + _score.ToString();
        _lifeText.text = "LIFE: " + _life.ToString();
    }

    public void DestroyOneSelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
