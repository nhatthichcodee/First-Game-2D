using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NTCMonoBehaviour
{
    [SerializeField] private JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;
    [SerializeField] private JunkSpawnPoints junkSpawnPoints;
    public SpawnPoints JunkSpawnPoints => junkSpawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.JunkSpawner != null)
        {
            return;
        }
        this.junkSpawner = GetComponent<JunkSpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.JunkSpawnPoints != null)
        {
            return;
        }

        this.junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    }
}
