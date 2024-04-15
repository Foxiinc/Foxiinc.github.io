using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _borderOfRotation;
    [SerializeField] private float _rotatePower;

    private Rigidbody2D _playerRigidBody;

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_playerRigidBody.velocity.y > _borderOfRotation) return;

        if (_playerRigidBody.velocity.y < -_borderOfRotation) return;

        transform.rotation = Quaternion.Euler(0, 0, _playerRigidBody.velocity.y * _rotatePower);
    }
}