using UnityEngine;

public abstract class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.left * (_speed * Time.fixedDeltaTime);
    }
}