using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 12f;

    private string _movementAxisName;
    private float _movementInputValue;

    void Start()
    {
        _movementAxisName = "Vertical" + playerNumber;
    }

    void Update()
    {
        _movementInputValue = Input.GetAxis(_movementAxisName);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {     
        Vector3 direction = transform.up * _movementInputValue;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
