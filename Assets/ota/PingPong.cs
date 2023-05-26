using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] float _speedX = 1.0f;
    [SerializeField] float _speedY = 1.0f;
    [SerializeField] float _amplitudeX = 1.0f;
    [SerializeField] float _amplitudeY = 1.0f;



    void Update()
    {
        transform.position = new Vector2(   Mathf.Cos(Time.time * _speedX) * _amplitudeX, 
                                            gameObject.transform.position.y + Mathf.Sin(Time.time * _speedY) * _amplitudeY);
    }
}
