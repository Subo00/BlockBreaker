using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //configuration parameters
    [Range(0.1f,5f)][SerializeField] private float _gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    public bool isAutoPlayEnabled = false;
    //State variables
    [SerializeField] private int _score = 0;
    
    
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
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = "SCORE: " + _score.ToString();
    }

    public void DestroyOneSelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
