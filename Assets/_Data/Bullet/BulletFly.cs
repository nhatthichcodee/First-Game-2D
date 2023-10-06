using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int moveSpeed = 1;
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
