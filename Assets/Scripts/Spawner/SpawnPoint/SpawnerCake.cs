public class SpawnerCake : Spawner<Cake, SpawnPointCake>
{
    protected override void OnGet(Cake cake)
    {
        cake.Collected += () => _pool.Release(cake);
        base.OnGet(cake);
    }

    protected override void OnRelease(Cake cake)
    {
        cake.Collected -= () => _pool.Release(cake);
        base.OnRelease(cake);
    }
}
