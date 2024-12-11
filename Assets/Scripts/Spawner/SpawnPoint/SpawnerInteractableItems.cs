public class SpawnerInteractableItems : Spawner<InteractableItem, SpawnPoint>
{
    protected override void OnGetIneractbableItem(InteractableItem interactableItem)
    {
        base.OnGetIneractbableItem(interactableItem);
        interactableItem.Collected += () => _pool.Release(interactableItem);
    }

    protected override void OnReleaseIneractbableItem(InteractableItem interactableItem)
    {
    }
}
