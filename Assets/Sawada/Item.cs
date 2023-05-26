using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour,IFallObject
{
    [SerializeField, Header("�o���m��"), Range(1, 100)]
    int _probability = 70;
    [SerializeField, Header("�����蔻��"), Space(20)]
    Collider2D _collider;
    [SerializeField, Header("�G�l�~�[�̉摜")]
    Renderer _renderer;
    [SerializeField, Header("���̃I�u�W�F�N�g��Rigitbody")]
    Rigidbody2D _rb;

    [Tooltip("�I�u�W�F�N�g�̗L������")]
    bool _isActive = false;
    [Tooltip("���ݓ���������")]
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
