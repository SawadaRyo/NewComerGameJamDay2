using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 移動が必要
/// 当たり判定はトリガー判定にする
/// HowMany()ってやつを使ってくれるとリロードされる弾の数が返されるよ
/// </summary>
public class JudgmentBar : MonoBehaviour
{
    [SerializeField] Transform _startPosition;
    [SerializeField] Transform _endPosition;
    [SerializeField, Tooltip("何秒かけて左から右に行くのか"), Range(1, 7)] float _time;
    float _speed;
    [SerializeField]float _timeCount;
    [SerializeField, Tooltip("触れてるゲームオブジェクト")] List<GameObject> _collisionGameObject;
    private void Update()
    {
        //場所が戻るようにする
        _timeCount += Time.deltaTime;
        if (_timeCount > _time)
        {
            _timeCount = 0;
            gameObject.transform.position = _startPosition.position;
        }
    }
    /// <summary>
    /// リロードするときにまた最初の位置に戻るようにする。
    /// </summary>
    void OnEnable()
    {
        gameObject.transform.position = _startPosition.position;
        float a = _startPosition.position.x - _endPosition.position.x;
        _speed = a / _time;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * _speed * -1;
        _timeCount = 0;
    }
    /// <summary>
    /// _collisionGameObjectっていう判定リストに触れているのを教える
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_collisionGameObject.Contains(collision.gameObject))
        {
            _collisionGameObject.Add(collision.gameObject);
        }
    }
    /// <summary>
    /// 離れたら判定リストから抜ける
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_collisionGameObject.Contains(collision.gameObject))
        {
            _collisionGameObject.Remove(collision.gameObject);
        }
    }

    /// <summary>
    /// Listの中で一番大きい数を持ってる人をとってくる
    /// </summary>
    /// <returns></returns>
    public int HowMany()
    {
        var num = 0;
        foreach (var i in _collisionGameObject)
        {
            if (i.gameObject.TryGetComponent<Judgment>(out _))
            {
                int temp = i.GetComponent<Judgment>().ReroadBulletNum;
                if (temp > num)
                {
                    num = temp;
                }
            }
        }
        StopMove();
        return num;
    }
    /// <summary>
    /// 動くのをやめさせる
    /// </summary>
    void StopMove()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
