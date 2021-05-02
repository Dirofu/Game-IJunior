using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
    [SerializeField] private TMP_Text _maxCoins;
    [SerializeField] private GameObject _gameWinScreen;

    private int _collectedCoins;

    public event UnityAction<int> CountChanged;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)
            coin.Picked += CoinPicked;
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
            coin.Picked -= CoinPicked;
    }

    private void Start()
    {
        _maxCoins.text = _coins.Length.ToString();
        CountChanged?.Invoke(_collectedCoins);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (_coins.Length == _collectedCoins)
        {
            _gameWinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void CoinPicked()
    {
        _collectedCoins++;
        CountChanged?.Invoke(_collectedCoins);
    }
}
