using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : NTCMonoBehaviour
{
    [SerializeField] protected DameSender dameSender;
    public DameSender DameSender => dameSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
    }

    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null)
        {
            return;
        }

        this.dameSender = transform.GetComponentInChildren<DameSender>();
    }
}
