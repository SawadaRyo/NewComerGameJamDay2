using System.Collections;
using UnityEngine;

public abstract class FallObject : MonoBehaviour,IFallObject
{
    [SerializeField, Header("塗りつぶす回数")]
    protected int _countChange = 1;
    [SerializeField, Header("出現確率"), Range(1, 100)]
    protected int _probability = 70;
    [SerializeField, Header("残留時間")]
    protected float _remainTime = 5f;
    [SerializeField, Header("当たり判定"), Space(20)]
    protected Collider2D _collider;
    [SerializeField, Header("エネミーの画像")]
    protected Renderer _renderer;
    [SerializeField, Header("このオブジェクトのRigitbody")]
    protected Rigidbody2D _rb;

    [Tooltip("オブジェクトの有効判定")]
    bool _isActive = false;
    protected GamejamScore _gamejamScore = null;

    public bool IsActive => _isActive;
    public int GenerateProbability => _probability;
    public abstract void HitResult();

    public void Create(Transform GeneratePos)
    {
        transform.position = GeneratePos.position;
        _rb.isKinematic = false;
        _isActive = true;
        _renderer.enabled = true;
        _collider.enabled = true;
        StartCoroutine(OnUpdate());
    }
    public virtual void Erase()
    {
        Debug.Log("Death");
        _rb.isKinematic = true;
        _rb.velocity = Vector2.zero;
        _isActive = false;
        _renderer.enabled = false;
        _collider.enabled = false;
    }
    IEnumerator OnUpdate()
    {
        float time = 0;
        while (_isActive)
        {
            time += Time.deltaTime;
            if (time >= _remainTime)
            {
                Erase();
            }
            yield return null;
        }
    }

    public void Instanse(GamejamScore gamejamScore)
    {
        _gamejamScore = gamejamScore;
        _rb.isKinematic = true;
        _isActive = false;
        _renderer.enabled = false;
        _collider.enabled = false;
    }
}
