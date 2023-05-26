using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour,IFallObject
{
    [SerializeField, Header("出現確率"), Range(1, 100)]
    int _probability = 70;
    [SerializeField, Header("当たり判定"), Space(20)]
    Collider2D _collider;
    [SerializeField, Header("エネミーの画像")]
    Renderer _renderer;
    [SerializeField, Header("このオブジェクトのRigitbody")]
    Rigidbody2D _rb;

    [Tooltip("オブジェクトの有効判定")]
    bool _isActive = false;
    [Tooltip("現在当たった回数")]
    int _hitCount = 0;

    public bool IsActive => _isActive;
    public int GenerateProbability => _probability;

    public void Create(Transform GeneratePos)
    {
        transform.position = GeneratePos.position;
        _rb.isKinematic = false;
        _isActive = true;
        _renderer.enabled = true;
        _collider.enabled = true;
    }
    public void Erase()
    {
        _rb.isKinematic = true;
        _isActive = false;
        _renderer.enabled = false;
        _collider.enabled = false;
    }
    public abstract int HitResult();
}
