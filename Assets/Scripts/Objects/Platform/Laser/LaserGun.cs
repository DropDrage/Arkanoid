using System.Collections;
using UnityEngine;

namespace Objects.Platform.Laser
{
    [RequireComponent(typeof(AudioSource))]
    public class LaserGun : MonoBehaviour
    {
        [Min(0f), SerializeField] private float timeBetweenShots;
        [SerializeField] private Vector2 shootPoint;

        [SerializeField] private GameObject laserPrefab;

        private Transform _transform;

        private LaserPool _laserPool;

        private Coroutine _shootCoroutine;
        private WaitForSeconds _delayBetweenShots;

        private AudioSource _shoutSoundSource;


        private void Awake()
        {
            _transform = transform;
            _laserPool = new LaserPool(laserPrefab);
            _delayBetweenShots = new WaitForSeconds(timeBetweenShots);

            _shoutSoundSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _shootCoroutine = StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                var laserObject = _laserPool.Get();
                laserObject.transform.localPosition = _transform.TransformPoint(shootPoint);
                _shoutSoundSource.Play();
                yield return _delayBetweenShots;
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_shootCoroutine);
        }


        private void OnDrawGizmosSelected()
        {
            var worldShootPoint = transform.TransformPoint(shootPoint);
            Gizmos.DrawWireSphere(worldShootPoint, 0.1f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(worldShootPoint, worldShootPoint + Vector3.up);
        }
    }
}
