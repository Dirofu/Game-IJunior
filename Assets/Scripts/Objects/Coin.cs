﻿using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _coinPicked;

    public event UnityAction Picked
    {
        add => _coinPicked?.AddListener(value);
        remove => _coinPicked?.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _coinPicked?.Invoke();
            Destroy(gameObject);
        }
    }
}
