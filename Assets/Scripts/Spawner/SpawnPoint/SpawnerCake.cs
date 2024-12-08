public class SpawnerCake : Spawner<FirstAidKit, SpawnPointCake>
{
    protected override void OnGet(FirstAidKit cake)
    {
        cake.Collected += () => _pool.Release(cake);
        base.OnGet(cake);
    }

    protected override void OnRelease(FirstAidKit cake)
    {
        cake.Collected -= () => _pool.Release(cake);
        base.OnRelease(cake);
    }
}
