using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [Range(-3f, 3f)][SerializeField] float xPush;
    [SerializeField] float yPush = 19f;
    [SerializeField] AudioClip[] ballSound;
    // state

    Vector2 paddleToBallVector;
    public bool hasStared = false;

    //Cached component ref
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStared)
        {
            LockBalltoPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f, 3f), yPush);
                hasStared = true;
                AudioClip clip = ballSound[2];
                myAudioSource.PlayOneShot(clip);
        }
    }

    private void LockBalltoPaddle()
    {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStared)
        {
            if (collision.gameObject.tag == "Block")
            {
                AudioClip clip = ballSound[0];
                myAudioSource.PlayOneShot(clip);
            }
            else
            {
                AudioClip clip = ballSound[1];
                myAudioSource.PlayOneShot(clip);
            }
        }

    }
}
