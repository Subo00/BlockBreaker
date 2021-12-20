using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameters
    [SerializeField] Paddle paddle0;
    [SerializeField] float xPush = 2f, yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    //state 
    Vector2 paddleToBallVector;
    private bool hasStarted = false;

    //Cached component references
    private AudioSource audioSource;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        paddleToBallVector = transform.position - paddle0.transform.position;
        audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.velocity = new Vector2(xPush,yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle0.transform.position.x, paddle0.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor),
                                            Random.Range(0f,randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            _rigidbody2D.velocity += velocityTweak;
        }
    }
}
