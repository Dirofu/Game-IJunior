using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private GameFinish _coins;

    private int _currentCount;

    private void OnEnable()
    {
        _coins.CountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _coins.CountChanged -= OnValueChanged;
    }

    private void OnValueChanged(int count)
    {
        _coinText.text = count.ToString();
    }
}
