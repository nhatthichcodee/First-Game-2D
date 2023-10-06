using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NTCMonoBehaviour
{
    [SerializeField] private JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.JunkSpawner != null)
        {
            return;
        }
        this.junkSpawner = GetComponent<JunkSpawner>();
    }
}
