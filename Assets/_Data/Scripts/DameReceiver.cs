using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class DameReceiver : NTCMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
    }
    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.maxHP;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        if(this.isDead) return;
        this.hp += add;
        if (this.hp > this.maxHP)
        {
            this.hp = this.maxHP;
        }
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;
        this.hp -= deduct;
        if (this.hp < 0)
        {
            this.hp = 0;
        }
        this.CheckIsDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead())
        {
            return;
        }

        this.isDead = true;
        this.OnDead();
    }

    public virtual void OnDead()
    {
        //override
    }
}
