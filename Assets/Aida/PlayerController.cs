using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[�̈ړ����x")]
    [SerializeField] private float speed = 1f;
    [Tooltip("�e�̃v���n�u")]
    [SerializeField] private GameObject bullet_Prefab;
    [Tooltip("�e�̔��ˈʒu")]
    [SerializeField] private Transform bullet_Muzzle;
    [Tooltip("�e���̍ő�l")]
    [SerializeField] private int bullet_Max = 6;
    private int bullet_Count = 0; //�e��

    Rigidbody2D _rb;

    /// <summary>
    /// �e�̒e����Ԃ��v���p�e�B
    /// </summary>
    public int BulletCount 
    {
        get { return bullet_Count; }
        private set { bullet_Count = value; }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        BulletCount = bullet_Max;
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BulletCount > 0)
        {
           Instantiate(bullet_Prefab, bullet_Muzzle.transform.position, Quaternion.identity);
           BulletCount--;
           Debug.Log("�c��e����" + BulletCount + "��");
        }
        if(BulletCount > bullet_Max)
        {
            BulletCount = bullet_Max;
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
