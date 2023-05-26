using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFallObject
{
    /// <summary>
    /// オブジェクト有効判定
    /// </summary>
    public bool IsActive { get; }
    /// <summary>
    /// 出現確率
    /// </summary>
    public int GenerateProbability { get; }
    public void Instanse(GamejamScore gamejamScore);
    /// <summary>
    /// オブジェクト生成時の処理
    /// </summary>
    /// <param name="GeneratePos"></param>
    public void Create(Transform GeneratePos);
    /// <summary>
    /// hit時の処理
    /// </summary>
    /// <returns></returns>
    public void HitResult();
    /// <summary>
    /// オブジェクトの削除
    /// </summary>
    public void Erase();
}
