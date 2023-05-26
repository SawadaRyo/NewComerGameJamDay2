using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// プレイヤーのリロード操作
/// </summary>
public class Magazine : MonoBehaviour
{
    public int RemainingBullets { get => _remainingBullets; set => _remainingBullets = value; }
    [SerializeField, Tooltip("残弾の数")] private int _remainingBullets = 6;
    [SerializeField] int _magazineMax = 6;
    [SerializeField] Text _bulletText;
    [SerializeField] Text _maxBulletText;
    [SerializeField] JudgmentBar _judgmentBar;
    [SerializeField] GameObject _reroad;
    bool _reroading = false;
    private void Start()
    {
        _maxBulletText.text = $"{_magazineMax}";
    }
    private void Update()
    {
        //一回目のR ゲームバーを起こす
        if (//Input.GetKeyDown(KeyCode.R) &&
            _remainingBullets == 0 && _reroading == false)
        {
            Debug.Log("R1");
            _reroading = true;
            _reroad.gameObject.SetActive(true);
            _judgmentBar.gameObject.SetActive(true);
        }
        //二回目のR ゲームバーからリロードする弾の数を教える
        else if (Input.GetKeyDown(KeyCode.R) && _reroading == true)
        {
            Debug.Log("R2");
            _reroading = false;
            _remainingBullets += _judgmentBar.HowMany();
            if (_remainingBullets > _magazineMax)
            {
                _remainingBullets = _magazineMax;
            }
            _bulletText.text = $"{_remainingBullets}";
            _judgmentBar.gameObject.SetActive(false);
            _reroad.SetActive(false);
        }
    }

    public void Shot()
    {
        if(_bulletText == null || _maxBulletText == null)
        {
            return;
        }

        _remainingBullets--;
        _bulletText.text = $"{_remainingBullets}";
    }
}
