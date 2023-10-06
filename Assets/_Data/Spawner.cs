using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NTCMonoBehaviour
{

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count != 0)
        {
            return;
        }
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null)
        {
            return;         
        }

        this.holder = transform.Find("Holder");
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found");
            return null;
        }

        Transform newPrefab = this.GetObjetFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos,rotation);
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefabName == prefab.name)
            {
                return prefab;
            }
        }

        return null;
    }

    protected virtual Transform GetObjetFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
