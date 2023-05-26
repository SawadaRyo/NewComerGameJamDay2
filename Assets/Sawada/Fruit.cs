using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : FallObject
{
    [SerializeField, Header("スコア")] 
    int _scoreValue = 300;

    [Tooltip("現在当たった回数")]
    int _hitCount = 0;

    public override void Erase()
    {
        _gamejamScore?.Addscore(_scoreValue);
        base.Erase();
    }
    public override void HitResult()
    {
        if (_hitCount == _countChange)
        {
            _gamejamScore?.Addscore(_scoreValue);
            Erase();
        }
        else if (_hitCount < _countChange)
        {
            _hitCount++;
        }
    }
}
