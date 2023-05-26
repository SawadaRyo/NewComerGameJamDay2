using System.Collections;
using UnityEngine;

public abstract class FallObject : MonoBehaviour,IFallObject
{
    [SerializeField, Header("�h��Ԃ���")]
    protected int _countChange = 1;
    [SerializeField, Header("�o���m��"), Range(1, 100)]
    protected int _probability = 70;
    [SerializeField, Header("�c������")]
    protected float _remainTime = 5f;
    [SerializeField, Header("�����蔻��"), Space(20)]
    protected Collider2D _collider;
    [SerializeField, Header("�G�l�~�[�̉摜")]
    protected Renderer _renderer;
    [SerializeField, Header("���̃I�u�W�F�N�g��Rigitbody")]
    protected Rigidbody2D _rb;

    [Tooltip("�I�u�W�F�N�g�̗L������")]
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
