using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float clampMin = 1f, clampMax = 20f;

    //cached references
    private GameSession gameSession;
    private Ball ball;
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), clampMin, clampMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(gameSession.isAutoPlayEnabled)
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            return mousePosX;
        }
    }

}
