using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) {
            DisplayScore();
        }
    }

    private void DisplayScore()
    {
        TimerController.instance.EndTimer();
        _text.text = "Time: " + Data.Instance.ElapsedTime.ToString("F2") + " seconds\n" +
                "Obstacles Collided: " + Data.Instance.ObstacleCollided + "\n" +
                "Cubes Interacted: " + Data.Instance.CubeInteracted + "/3";
    } 
}
