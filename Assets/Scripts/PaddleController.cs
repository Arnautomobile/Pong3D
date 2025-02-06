using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private int _playerNumber;
    [SerializeField] private float _speed;

    private Vector3 _direction;


    void Start()
    {
        if (_playerNumber != 1 && _playerNumber != 2) {
            Debug.Log("Wrong player number assigned for this paddle.");
        }

        _direction = Vector3.zero;
    }


    void Update()
    {
        if (_playerNumber == 1) {
            _direction = new Vector3(0, 0, Input.GetAxis("Paddle Left"));
        }
        else if (_playerNumber == 2) {
            _direction = new Vector3(0, 0, Input.GetAxis("Paddle Right"));
        }
        else {
            _direction = Vector3.zero;
        }

        transform.position += _direction * _speed * Time.deltaTime;

        if (transform.position.z > 4) {
            transform.position = new Vector3(transform.position.x, 0.5f, 4f);
        }
        else if (transform.position.z < -4) {
            transform.position = new Vector3(transform.position.x, 0.5f, -4f);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        BallMovement ballMovement;
        if ((ballMovement = collider.GetComponent<BallMovement>()) != null) {

            Vector3 resultDirection = collider.transform.position - transform.position;
            resultDirection.x += _playerNumber == 1 ? 1 : -1;
            ballMovement.Direction = resultDirection.normalized;
            ballMovement.Speed += ballMovement.Speed * GameManager.Instance.BallAcceleration;
        }
    }
}
