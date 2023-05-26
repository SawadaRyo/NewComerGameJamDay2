using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : FallObject
{
    [SerializeField, Header("ÉXÉRÉA")] 
    int _scoreValue = 300;

    [Tooltip("åªç›ìñÇΩÇ¡ÇΩâÒêî")]
    int _hitCount = 0;

    public override void HitResult()
    {
        if (_hitCount == _countChange)
        {
            _gamejamScore.Addscore(_scoreValue);
        }
        else if (_hitCount < _countChange)
        {
            _hitCount++;
        }
    }
}
