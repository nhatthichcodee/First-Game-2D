using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NTCMonoBehaviour
{
    [SerializeField] private JunkSpawnerCtrl junkSpawnerCtrl;
    public JunkSpawnerCtrl JunkSpawnerCtrl => junkSpawnerCtrl;

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

    protected virtual void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, randPoint.position, randPoint.rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning),1f);
    }
}
