using UnityEngine;


public class LoseCollider : MonoBehaviour
{
	private GameSession _gameSession;
	private void Start()
	{
		_gameSession =  FindObjectOfType<GameSession>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            _gameSession.LoseLife();
            collision.gameObject.GetComponent<Ball>().Restart();
        }

        if(collision.tag == "Gold")
            collision.gameObject.SetActive(false);
    }
}
