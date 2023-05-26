using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamejamScore : MonoBehaviour
{
    public int _score;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;//デフォルト値
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", _score);
    }
    public void Addscore(int score)
    {
        _score += score;
    }
}
