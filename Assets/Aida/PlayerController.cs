using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[�̑��x")]
    [SerializeField] private float speed = 1f;
    [Tooltip("�e�̃v���n�u")]
    [SerializeField] private GameObject bullet_Prefab;
    [Tooltip("�e�̒e��")]
    [SerializeField] private int bullet_Count = 6;
    [Tooltip("�e�̔��ˈʒu")]
    [SerializeField] private Transform muzzle;
    
    Rigidbody2D _rb;

    /// <summary>
    /// �e�̒e����Ԃ��v���p�e�B
    /// </summary>
    public int BulletCount 
    {
        get { return bullet_Count; }
        set { bullet_Count = value; }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BulletCount > 0)
        {
          Instantiate(bullet_Prefab, muzzle.position, Quaternion.identity);
          bullet_Count--;
          Debug.Log("�c��e����" + BulletCount + "��");
        }
    }

    /// <summary>
    /// �L�����̐����ړ�
    /// </summary>
    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        Vector2 v = _rb.velocity;
        v = h * speed * Vector2.right;
        _rb.velocity = v;
    }
}
