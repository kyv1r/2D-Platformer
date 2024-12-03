using System;
using System.Collections;
using System.Collections.Generic;
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
