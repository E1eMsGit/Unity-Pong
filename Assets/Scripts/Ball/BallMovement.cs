using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 7f;
  
    private int _hitCounter = 0;

    public Vector3 Direction { get; set; }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            transform.position + Direction,
            speed * Time.deltaTime
            );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.GetComponent<PaddleHit>())
        {
            _hitCounter++;
            if (_hitCounter == 2)
            {
                speed += 0.5f;
                _hitCounter = 0;
            }
        }
    }

    private void OnEnable()
    {
        _hitCounter = 0;
        speed = 6f;
    }
}
