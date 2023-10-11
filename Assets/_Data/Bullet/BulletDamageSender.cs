using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DameSender
{
    public override void Send(DameReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
