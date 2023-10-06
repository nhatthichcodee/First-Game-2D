using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : NTCMonoBehaviour
{
    [SerializeField] private JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl => junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();        
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null)
        {
            return;
        }
        this.junkCtrl = GetComponent<JunkCtrl>();
    }

    protected virtual void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, transform.position, transform.rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning),1f);
    }
}
