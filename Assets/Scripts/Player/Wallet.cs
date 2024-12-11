using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private float _countCoin;

    public float CountCoin => _countCoin;

    public void AddMoney(float value)
    {
        _countCoin += value;
    }
}
