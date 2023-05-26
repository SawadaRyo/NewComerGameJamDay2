using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjectManager : MonoBehaviour
{
    [SerializeField, Header("生成するフルーツのプレハブ")]
    Fruit[] _fruit = null;
    [SerializeField, Header("生成するプレハブ")]
    Item[] _item = null;
    [SerializeField, Header("生成する座標")]
    Transform[] _generatePos = null;
    [SerializeField, Range(3, 10), Header("生成間隔")]
    float _intervalTime = 5;
    [SerializeField, Range(1, 100), Header("初期生成")]
    int _count = 1;
    [SerializeField, Space(20)]
    GamejamScore _gamejamScore = null;


    [Tooltip("")]
    bool _generateEnabled = true;
    [Tooltip("")]
    bool _isGame = false;
    [Tooltip("")]
    List<IFallObject>[] _fallObjectList = null;

    float IntervalTime => UnityEngine.Random.Range(0.1f, _intervalTime);

    void Start()
    {
        _isGame = true;
        _generateEnabled = true;
        _fallObjectList = new List<IFallObject>[_fruit.Length + _item.Length];
        if (_fruit.Length > 0)
        {
            FirstInstance(_fruit, _count);
        }
        if (_item.Length > 0)
        {
            FirstInstance(_item, _count);
        }

        for (int i = 0; i < _fallObjectList.Length; i++)
        {
            StartCoroutine(GenerateEnemy(_fallObjectList[i]));
        }
    }

    public void FirstInstance(FallObject[] enemy, int count)
    {
        for (int i = 0;i < enemy.Length; i++)
        {
            _fallObjectList[i] = new();
            for (int j = 0; j < count; j++)
            {
                FallObject prefab = Instantiate<FallObject>(enemy[i]);
                prefab.Instanse(_gamejamScore);
                _fallObjectList[i].Add(prefab);
            }
        }
    }

    public void FinishGame()
    {
        _isGame = false;
    }

    public IEnumerator GenerateEnemy(List<IFallObject> fallObjects)
    {
        while (true)//ToDoゲーム終了時に止まるようにする
        {
            Debug.Log("Looping");
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
            yield return null;
        }
    }
}
