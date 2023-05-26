using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    [SerializeField]
    float _speed = -1;
    [SerializeField]
    float _rotate = 2;
    Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _rb.velocity = new Vector2(0, _speed);
        transform.Rotate(new Vector3(0, 0, _rotate));
    }
}
