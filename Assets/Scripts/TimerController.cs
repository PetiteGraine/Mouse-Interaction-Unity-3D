using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
  public static TimerController instance;
  public TextMeshProUGUI _text;
  private TimeSpan _timePlaying;
  private bool _isTimerGoing;
  private bool _isGameGoing;

  private void Awake()
  {
    instance = this;
  }

  private void FixedUpdate()
  {
    if (_isGameGoing && Input.anyKeyDown && !_isTimerGoing)
      {
        BeginTimer();
      }
  }

    private void Start()
  {
    _text.text = "Time: 00:00.00";
    _isTimerGoing = false;
    _isGameGoing = true;
  }

  private void BeginTimer()
  {
    _isTimerGoing = true;
    Data.Instance.ElapsedTime = 0f;

    StartCoroutine(UpdateTimer());
  }

  public void EndTimer()
  {
    _isTimerGoing = false;
    _isGameGoing = false;
  }

  private IEnumerator UpdateTimer()
  {
    while (_isTimerGoing)
    {
      Data.Instance.ElapsedTime += Time.deltaTime;
      _timePlaying = TimeSpan.FromSeconds(Data.Instance.ElapsedTime);
      string timePlayingStr = "Time: " + _timePlaying.ToString("mm':'ss'.'ff");
      _text.text = timePlayingStr;

      yield return null;
    }
  }
}