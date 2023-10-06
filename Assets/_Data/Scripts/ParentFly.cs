using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : NTCMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        this.Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.moveSpeed * this.direction * Time.deltaTime);
    }
}