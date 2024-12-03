using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Collected;

    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false); 
    }
}
