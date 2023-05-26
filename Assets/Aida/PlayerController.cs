using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float bullet_Speed = 20f;

    [Tooltip("�v���C���[�̈ړ����x")]
    [SerializeField] private float speed = 1f;
    [Tooltip("�e�̃v���n�u")]
    [SerializeField] private GameObject bullet_Prefab;
    [Tooltip("�e�̔��ˈʒu")]
    [SerializeField] private Transform bullet_Muzzle;
    private bool stop = false; //�v���C���[���씻��
    [SerializeField] private Magazine magazine;
    [SerializeField, Tooltip("�����m��"), Range(0, 100)] private int bullet_Probability;
    [SerializeField] private GameObject bullet_Special;


    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    void Update()
    {
        if (stop) return;
        if (Input.GetKeyDown(KeyCode.Space) && magazine.RemainingBullets > 0 && magazine._reroading == false)
        {
            var s = Random.Range(0, 100);
            if (magazine.Strong)
            {
                GameObject a = Instantiate(bullet_Special, bullet_Muzzle.transform.position, Quaternion.identity);

                BulletController b = a.GetComponent<BulletController>();
                b.BulletSpeed = bullet_Speed;

                magazine.Shot();
            }
            else
            {
                if (s <= bullet_Probability)
                {
                    GameObject a = Instantiate(bullet_Special, bullet_Muzzle.transform.position, Quaternion.identity);

                    BulletController b = a.GetComponent<BulletController>();
                    b.BulletSpeed = bullet_Speed;

                    magazine.Shot();
                }
                else
                {
                    Instantiate(bullet_Prefab, bullet_Muzzle.transform.position, Quaternion.identity);
                    magazine.Shot();
                }
                Debug.Log("�c��e����" + magazine.RemainingBullets + "��");
            }
               
            
        }
    }
    /// <summary>
    /// �L�����̐����ړ�
    /// </summary>
    void FixedUpdate()
    {
        if (stop) return;
        var h = Input.GetAxisRaw("Horizontal");
        Vector2 v = _rb.velocity;
        v = h * speed * Vector2.right;
        _rb.velocity = v;
    }

    public void Stop()
    {
        stop = true;
    }
}
