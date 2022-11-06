using Objects.Ball;
using UnityEngine;
using UnityEngine.Events;

public class BallFallTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent ballFellOut;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<OnBounceSoundPlayer>(out _))
        {
            ballFellOut.Invoke();
        }
    }
}
