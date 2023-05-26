using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : FallObject
{
    [SerializeField, Header("�X�R�A")] 
    int _scoreValue = 300;

    [Tooltip("���ݓ���������")]
    int _hitCount = 0;

    public override void Erase()
    {
        _gamejamScore.Changescore(-_scoreValue);
        base.Erase();
    }
    public override void HitResult()
    {
        if (_hitCount == _countChange)
        {
            _gamejamScore.Changescore(_scoreValue);
        }
        else if (_hitCount < _countChange)
        {
            _hitCount++;
        }
    }
}
