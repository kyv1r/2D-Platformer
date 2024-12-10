public class SpawnerCoins : Spawner<Coin, SpawnPoint>
{
    protected override void OnGetIneractbableItem(Coin coin)
    {
        coin.Collected += () => _pool.Release(coin);
        base.OnGetIneractbableItem(coin);
    }

    protected override void OnRelease(Coin coin)
    {
        coin.Collected -= () => _pool.Release(coin);
        base.OnRelease(coin);
    }
}
