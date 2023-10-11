using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null)
        {
            return;
        }

        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null)
        {
            return;
        }

        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.BulletCtrl.DameSender.Send(other.transform);
    }
}
