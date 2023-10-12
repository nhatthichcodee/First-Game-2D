using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : NTCMonoBehaviour
{
    [SerializeField] private JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 4f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 5;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();        
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null)
        {
            return;
        }
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit())
        {
            return;
        }

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay)
        {
            return;
        }

        this.randomTimer = 0;
        Transform randPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();
        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, randPoint.position, randPoint.rotation);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
