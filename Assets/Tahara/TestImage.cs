using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImage : MonoBehaviour
{
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
        }
    }

    public void ControlTime()
    {
        _isStop ^= true;
    }
}