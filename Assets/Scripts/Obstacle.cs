using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) {
            ++Data.Instance.ObstacleCollided;
        }
    }
}
