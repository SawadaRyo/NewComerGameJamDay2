using UnityEngine;
/// <summary>
/// JudgmentBarによって判定され、返す弾の数が調整できるようにする
/// </summary>
public class Judgment : MonoBehaviour
{
    public int ReroadBulletNum { get => _reroadBulletNum; set => _reroadBulletNum = value; }
    [SerializeField, Tooltip("返す弾の数")] private int _reroadBulletNum;
    [SerializeField]
    public ColorType ColorType = ColorType.White;
}

public enum ColorType
{
    White,
    Red,
    Blue
}

