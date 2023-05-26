using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FallObjectManager : MonoBehaviour
{
    [SerializeField, Header("��������t���[�c�̃v���n�u")]
    Fruit[] _fruit = null;
    [SerializeField, Header("��������v���n�u")]
    Item[] _item = null;
    [SerializeField, Header("����������W")]
    Transform[] _generatePos = null;
    [SerializeField, Range(3, 10), Header("�����Ԋu")]
    float _intervalTime = 5;
    [SerializeField, Range(1, 100), Header("��������")]
    int _count = 0;


    [Tooltip("")]
    bool _generateEnabled = false;
    [Tooltip("")]
    List<IFallObject>[] _fallObjectList = null;

    float IntervalTime => UnityEngine.Random.Range(0.1f, _intervalTime);

    void Start()
    {
        _fallObjectList = new List<IFallObject>[_fruit.Length + _item.Length];
        if (_fruit.Length > 1)
        {
            Array.ForEach(_fruit, x => FirstInstance(x, _count));
        }
        if (_item.Length > 1)
        {
            Array.ForEach(_item, x => FirstInstance(x, _count));
        }

        for (int i = 0; i < _fallObjectList.Length; i++)
        {
            StartCoroutine(GenerateEnemy(_fallObjectList[i]));
        }
    }

    public void FirstInstance(IFallObject enemy, int count)
    {
        for (int i = 0; i < _count; i++)
        {
            _fallObjectList[i] = new();
            for (int j = 0; j < count; j++)
            {
                IFallObject prefab = null;
                if (enemy is Fruit fruit)
                {
                    prefab = Instantiate<Fruit>(fruit);
                }
                if (enemy is Item item)
                {
                    prefab = Instantiate<Item>(item);
                }
                _fallObjectList[i].Add(prefab);
            }
        }
    }

    public IEnumerator GenerateEnemy(List<IFallObject> fallObjects)
    {
        while (true)//ToDo�Q�[���I�����Ɏ~�܂�悤�ɂ���
        {
            int probability = UnityEngine.Random.Range(0, 100);
            foreach (var e in fallObjects)
            {
                if (e.IsActive || !_generateEnabled) continue;
                else if (!e.IsActive && _generateEnabled && e.GenerateProbability >= probability)
                {
                    e.Create(_generatePos[UnityEngine.Random.Range(0, _generatePos.Length)]);
                    float time = IntervalTime;
                    _generateEnabled = false;
                    yield return new WaitForSeconds(time);
                    _generateEnabled = true;
                    break;
                }
            }
        }
    }
}
