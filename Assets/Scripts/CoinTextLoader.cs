using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinTextLoader : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinText;
        
        private void OnEnable()
        {
            _coinText.text = SaveMethods.Load().CoinCount.ToString();
        }
    }
}