using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : NTCMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DameReceiver damageReceiver = obj.GetComponent<DameReceiver>();
        if (damageReceiver == null)
        {
            return;
        }
        this.Send(damageReceiver);
    }

    public virtual void Send(DameReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
