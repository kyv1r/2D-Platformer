public class SpawnerCake : Spawner<FirstAidKit, SpawnPoint>
{
    protected override void OnGetIneractbableItem(FirstAidKit cake)
    {
        cake.Collected += () => _pool.Release(cake);
        base.OnGetIneractbableItem(cake);
    }

    protected override void OnRelease(FirstAidKit cake)
    {
        cake.Collected -= () => _pool.Release(cake);
        base.OnRelease(cake);
    }
}
