using System;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _forceOfJump;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Jump();
    }

    public event Action OnJump;

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _forceOfJump;

        OnJump?.Invoke();
    }
}