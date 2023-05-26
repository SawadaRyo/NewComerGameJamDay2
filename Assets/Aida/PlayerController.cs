using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度")]
    [SerializeField] private float speed = 1f;
    [Tooltip("弾のプレハブ")]
    [SerializeField] private GameObject bullet_Prefab;
    [Tooltip("弾の発射位置")]
    [SerializeField] private Transform bullet_Muzzle;
    [Tooltip("弾数の最大値")]
    [SerializeField] private int bullet_Max = 6;
    private int bullet_Count = 0; //弾数

    Rigidbody2D _rb;

    /// <summary>
    /// 弾の弾数を返すプロパティ
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
    /// 弾の発射
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BulletCount > 0)
        {
           Instantiate(bullet_Prefab, bullet_Muzzle.transform.position, Quaternion.identity);
           BulletCount--;
           Debug.Log("残り弾数は" + BulletCount + "個");
        }
        if(BulletCount > bullet_Max)
        {
            BulletCount = bullet_Max;
        }
    }

    /// <summary>
    /// キャラの水平移動
    /// </summary>
    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        Vector2 v = _rb.velocity;
        v = h * speed * Vector2.right;
        _rb.velocity = v;
    }
}
