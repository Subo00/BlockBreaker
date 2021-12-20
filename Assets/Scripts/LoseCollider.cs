using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
            SceneManager.LoadScene("GameOver");

        if(collision.tag == "Gold")
            collision.gameObject.SetActive(false);
    }
}
