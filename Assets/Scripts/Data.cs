using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance { get; private set; }
    public float ElapsedTime = 0f;
    public int ObstacleCollided = 0;
    public int CubeInteracted = 0;

    private void Awake()
    {
        Instance = this;
    }
}