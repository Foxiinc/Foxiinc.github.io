using DG.Tweening;
using UnityEngine;

public class GameStartPlayerPositionSetter : MonoBehaviour
{
    [SerializeField] private float _timeToMove;

    [SerializeField] private Transform _endMarker;
    
    private PlayerJumper _playerJumper;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _playerJumper = GetComponent<PlayerJumper>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerJumper.enabled = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        
        MoveToStart();
    }

    private void MoveToStart()
    {
        transform.DOMove(_endMarker.position, _timeToMove).OnComplete(() =>
        {
            _playerJumper.enabled = true;
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        });
    }
}
