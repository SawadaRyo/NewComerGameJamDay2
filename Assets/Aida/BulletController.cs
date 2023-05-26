using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Tooltip("’e‚Ì‘¬“x")]
    [SerializeField] private float bullet_Speed = 1f;
    Rigidbody2D _rb;

    void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
      _rb.velocity = Vector3.up * bullet_Speed;
    }
}
