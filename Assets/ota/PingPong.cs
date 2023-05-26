using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] float _speedX = 1.0f;
    [SerializeField] float _speedY = 1.0f;
    [SerializeField] float _amplitudeX = 1.0f;
    [SerializeField] float _amplitudeY = 1.0f;
    [SerializeField] float _x;

    private void Start()
    {
        _x = gameObject.transform.position.x;
    }

    float n = 0;
    void Update()
    {
        n += Time.deltaTime;
        transform.position = new Vector2(_x + Mathf.Cos(n * _speedX) * _amplitudeX, 
                                            gameObject.transform.position.y + Mathf.Sin(n * _speedY) * _amplitudeY);
    }
}
