using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    public int playerNumber = 1;

    private float _ballDirection;
    private AudioSource _ballHitSound;

    private void Start()
    {
        _ballDirection = playerNumber == 1 ? 1 : -1;
        _ballHitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.GetComponent<BallMovement>())
        {
            BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
            ball.Direction = new Vector3(_ballDirection, Random.Range(0f, 1f) * 2 - 1).normalized;
            _ballHitSound.Play();
        }
    }
}
