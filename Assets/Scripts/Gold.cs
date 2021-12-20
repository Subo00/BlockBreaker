using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    GameSession gameSession;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameSession.AddToScore(1);
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
}
