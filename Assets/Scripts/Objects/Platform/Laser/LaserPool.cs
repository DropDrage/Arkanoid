using UnityEngine;
using UnityEngine.Pool;

namespace Objects.Platform.Laser
{
    public class LaserPool : IReturnablePool<GameObject>
    {
        private readonly IObjectPool<GameObject> _pool;

        private readonly Transform _lasersContainer;
        private readonly GameObject _prefab;


        public LaserPool(GameObject prefab)
        {
            _pool = new ObjectPool<GameObject>(CreateLaser, OnTakeFromPool, OnReturnedToPool);
            _lasersContainer = new GameObject("Lasers pool").transform;
            _prefab = prefab;
        }

        private GameObject CreateLaser()
        {
            var laserObject = Object.Instantiate(_prefab, _lasersContainer);
            laserObject.GetComponent<ReturnToPoolOnCollision>().Pool = this;
            return laserObject;
        }

        private void OnTakeFromPool(GameObject laserObject)
        {
            laserObject.SetActive(true);
        }

        private void OnReturnedToPool(GameObject laserObject)
        {
            laserObject.SetActive(false);
        }


        public GameObject Get() => _pool.Get();

        public void Return(GameObject laserObject)
        {
            _pool.Release(laserObject);
        }

        public void Clear()
        {
            _pool.Clear();
            Object.Destroy(_lasersContainer.gameObject); //ToDo or don't destroy lasers?
        }
    }
}
