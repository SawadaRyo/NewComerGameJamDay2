using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestImage : MonoBehaviour
{
    [SerializeField]
    UnityEvent _timeUpEvent;

    [SerializeField]
    Text _timerText = default;

    [SerializeField]
    GameObject resultPanel;

    [SerializeField]
    float _interval = 30f;

    float _timer = 0f;

    bool _isStop = false;

    private void Start()
    {
        _timer = _interval;
    }

    void Update()
    {

        _timerText.text = _timer.ToString("00:00");

        if (_isStop == true) { return; }

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = 0;

            resultPanel.SetActive(true);
            ControlTime();
            _timeUpEvent.Invoke();
        }
    }
    public void TimePlus(float PlusNum)
    {
        _interval += PlusNum;
    }

    public void ControlTime()
    {
        _isStop ^= true;
    }
}