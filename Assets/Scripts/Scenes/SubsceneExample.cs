using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(GameObjectDeclareReferencedObjectsGroup))]
public class SubsceneExample : GameObjectConversionSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((PrefabReference prefabReference) =>
        {
            DeclareReferencedPrefab(prefabReference.Prefab);

            var entity = GetPrimaryEntity(prefabReference);
            var prefab = GetPrimaryEntity(prefabReference.Prefab);

            var component = new PrefabEntityReference { Prefab = prefab };
            DstEntityManager.AddComponentData(entity, component);
        });
    }
}