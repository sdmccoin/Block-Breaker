using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX;
    [SerializeField] float velocityY;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVector;
    bool isMoving;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        isMoving = false;
        velocityX = 2f;
        velocityY = 15f;
            
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            LockToPaddle();
            LaunchOnClick();
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            isMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMoving)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
