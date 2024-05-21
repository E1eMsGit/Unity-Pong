using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool IsGoal { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.GetComponent<BallMovement>())
        {
            IsGoal = true;
        }
    }

    void OnEnable()
    {
        IsGoal = false;
    }

}
