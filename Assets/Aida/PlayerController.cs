using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの速度")]
    [SerializeField] private float speed = 1f;
    [Tooltip("弾のプレハブ")]
    [SerializeField] private GameObject bullet_Prefab;
    [Tooltip("弾の弾数")]
    [SerializeField] private int bullet_Count = 6;
    [Tooltip("弾の発射位置")]
    [SerializeField] private Transform muzzle;
    
    Rigidbody2D _rb;

    /// <summary>
    /// 弾の弾数を返すプロパティ
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
    /// 弾の発射
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BulletCount > 0)
        {
          Instantiate(bullet_Prefab, muzzle.position, Quaternion.identity);
          bullet_Count--;
          Debug.Log("残り弾数は" + BulletCount + "個");
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
