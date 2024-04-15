using TMPro;
using UnityEngine;

public class CoinDrawer : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;

    private CoinCollector _coinCollector;

    private void Awake()
    {
        _coinCollector = FindObjectOfType<CoinCollector>();
    }

    private void OnEnable()
    {
        if (_coinCollector != null)
        {
            _coinCollector.OnCoinAdd += DrawCoin;
        }
    }
    
    private void OnDisable()
    {
        if (_coinCollector != null)
        {
            _coinCollector.OnCoinAdd -= DrawCoin;
        }
    }

    private void DrawCoin(double coinCount)
    {
        _coinText.text = coinCount.ToString();
    }
}
