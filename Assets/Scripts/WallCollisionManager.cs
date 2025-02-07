using UnityEngine;

public class WallCollisionManager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        BallMovement ballMovement;
        if ((ballMovement = collider.GetComponent<BallMovement>()) != null) {
            ballMovement.Direction = new Vector3(ballMovement.Direction.x, 0, ballMovement.Direction.z * -1);
        }
    }
}
