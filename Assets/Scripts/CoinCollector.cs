using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinCollector : MonoBehaviour
{
    public event Action<double> OnCoinAdd;
    
    public double CoinCapital;
    
    [SerializeField] private double _coinPrice = 0.1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinCapital += _coinPrice;
            OnCoinAdd?.Invoke(CoinCapital);
        }
    }
}