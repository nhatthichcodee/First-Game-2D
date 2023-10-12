using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameReceiver : DameReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;

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

        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }
    public override void OnDead()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void Reborn()
    {
        this.maxHP = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
