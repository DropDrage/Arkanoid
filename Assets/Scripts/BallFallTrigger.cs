using Managers;
using Objects.Ball;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

public class BallFallTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent ballFellOut;

    private BallsManager _ballsManager;


    [Inject]
    private void Construct(BallsManager ballsManager)
    {
        _ballsManager = ballsManager;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_ballsManager.IsBallLast)
        {
            if (other.TryGetComponent<OnBounceSoundPlayer>(out _))
            {
                ballFellOut.Invoke();
            }
        }
        else
        {
            _ballsManager.RemoveBall(other.gameObject);
        }
    }
}
