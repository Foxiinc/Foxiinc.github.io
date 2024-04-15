using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class ObjectCreator : MonoBehaviour
{
    [SerializeField] protected Transform _prefab;
    [SerializeField] private Transform _player;

    [SerializeField] private int _count;

    [SerializeField] protected List<Transform> _allObjects = new();

    [SerializeField] private float _despawnOffset;

    [SerializeField] protected float _betweenOffsetX;
    
    private void Update()
    {
        DestroyBackground();
    }

    private void DestroyBackground()
    {
        Spawn();

        if (_allObjects[0].position.x > _player.position.x - _despawnOffset) return;

        RemoveFirst();
    }

    private void Spawn()
    {
        if (_allObjects.Count >= _count) return;

        var spawnPosition = CalculatePosition();

        var backGround = Instantiate(_prefab, spawnPosition, quaternion.identity);
        _allObjects.Add(backGround);
    }

    protected virtual Vector3 CalculatePosition()
    {
        var spawnPos = _allObjects[^1].position;

        spawnPos += Vector3.right * (_prefab.localScale.x*_betweenOffsetX);

        return spawnPos;
    }

    private void RemoveFirst()
    {
        Destroy(_allObjects[0].gameObject);
        _allObjects.RemoveAt(0);
    }
}