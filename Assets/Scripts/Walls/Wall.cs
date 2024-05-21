using UnityEngine;

public class Wall : MonoBehaviour
{
    public float bounceDirection = 1;

    private AudioSource _ballHitSound;

    private void Start()
    {
        _ballHitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if (collision.gameObject.GetComponent<BallMovement>())
        {
            BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
            ball.Direction = ball.Direction + new Vector3(0, bounceDirection).normalized;
            _ballHitSound.Play();
        }
    }
}
