using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private int _playerNumber;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ball")) {
            Destroy(collider.gameObject);
            GameManager.Instance.Scored(_playerNumber);
        }
    }
}
