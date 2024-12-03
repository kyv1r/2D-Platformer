using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : Spawner<Coin, SpawnPointCoin>
{
    protected override void OnGet(Coin coin)
    {
        coin.Collected += () => _pool.Release(coin);
        base.OnGet(coin);
    }

    protected override void OnRelease(Coin coin)
    {
        coin.Collected -= () => _pool.Release(coin);
        base.OnRelease(coin);
    }
}
