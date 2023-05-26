using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFallObject
{
    /// <summary>
    /// �I�u�W�F�N�g�L������
    /// </summary>
    public bool IsActive { get; }
    /// <summary>
    /// �o���m��
    /// </summary>
    public int GenerateProbability { get; }
    public void Instanse(GamejamScore gamejamScore);
    /// <summary>
    /// �I�u�W�F�N�g�������̏���
    /// </summary>
    /// <param name="GeneratePos"></param>
    public void Create(Transform GeneratePos);
    /// <summary>
    /// hit���̏���
    /// </summary>
    /// <returns></returns>
    public void HitResult();
    /// <summary>
    /// �I�u�W�F�N�g�̍폜
    /// </summary>
    public void Erase();
}
