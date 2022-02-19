// Runtime component
using Unity.Entities;

public struct PrefabEntityReference : IComponentData
{
    public Entity Prefab;
}