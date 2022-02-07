using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    //configuration parameters
    [SerializeField] AudioClip[] goldSounds;

    //cached memory
    GameSession gameSession;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {                               //get a random clip from array
           AudioSource.PlayClipAtPoint(goldSounds[UnityEngine.Random.Range(0,goldSounds.Length)],
                                        Camera.main.transform.position, 0.5f);
            
            gameSession.AddToScore(1);
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
}
