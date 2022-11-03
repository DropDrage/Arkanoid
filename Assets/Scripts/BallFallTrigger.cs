using Objects.Ball_Components;
using UnityEngine;
using UnityEngine.Events;

public class BallFallTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent ballFellOut;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Ball>(out _))
        {
            ballFellOut.Invoke();
        }
    }
}
