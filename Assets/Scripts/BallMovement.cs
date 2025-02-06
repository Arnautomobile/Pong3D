using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    public Vector3 Direction { get; set; }
    public float Speed { get => _speed; set => _speed = value; }


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (GameManager.Instance.StartingPlayer == 1) {
            Direction = Vector3.left;
        }
        else if (GameManager.Instance.StartingPlayer == 2) {
            Direction = Vector3.right;
        }
        else {
            Debug.Log("Starting player is undefined.");
            Direction = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Direction * _speed);
    }
}
