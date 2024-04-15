using UnityEngine;

namespace DefaultNamespace
{
    public class WallCreator : ObjectCreator
    {
        [SerializeField] private float _randomRangeForYSpawn;

        protected override Vector3 CalculatePosition()
        {
            var random = Random.Range(-_randomRangeForYSpawn, _randomRangeForYSpawn);

            var spawnPos = new Vector3(_allObjects[^1].position.x, 0);

            spawnPos += Vector3.right * (_prefab.localScale.x * 1.44f) + new Vector3(_betweenOffsetX, random);

            return spawnPos;
        }
    }
}