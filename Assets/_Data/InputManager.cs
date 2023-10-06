using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    [SerializeField] protected Vector3 mouseWorldPos;
    [SerializeField] protected float onFiring = 0;
    public static InputManager Instance => instance;
    public Vector3 MouseWorldPos => mouseWorldPos;
    public float OnFiring => onFiring;

    private void Awake()
    {
        if (InputManager.instance != null)
        {
            Debug.LogError("Only 1 InputManager Singleton");
        }
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
