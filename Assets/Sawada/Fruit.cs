using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IFallObject
{
    [SerializeField, Header("塗りつぶす回数")] 
    int _countChange = 1;
    [SerializeField, Header("スコア")] 
    int _scoreValue = 300;
    [SerializeField, Header("出現確率"),Range(1,100)]
    int _probability = 70;
    [SerializeField, Header("残留時間")]
    float _remainTime = 5f;
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
        StartCoroutine(OnUpdate());
    }

    public void Erase()
    {
        _rb.isKinematic = true;
        _isActive = false;
        _renderer.enabled = false;
        _collider.enabled = false;
    }

    public int HitResult()
    {
        if(_hitCount == _countChange)
        {
            return _hitCount;
        }
        else if(_hitCount < _countChange)
        {
            _hitCount++;
        }
        return 0;
    }
    
    IEnumerator OnUpdate()
    {
        float time = 0;
        while(_isActive)
        {
            time += Time.deltaTime;
            if(time >= _remainTime)
            {
                Erase();
            }
            yield return null;
        }
    }
}
