using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoreTime : FallObject, IFallObject
{
    [SerializeField] TestImage _timeImage;
    [SerializeField] float _time = 3;
    private void Start()
    {
        _timeImage = FindObjectOfType<TestImage>();
    }
    public override void HitResult()
    {
        _timeImage.TimePlus(_time);
    }
}
