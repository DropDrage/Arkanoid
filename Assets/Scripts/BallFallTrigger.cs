using Managers;
using UnityEngine;
using VContainer;

public class BallFallTrigger : MonoBehaviour
{
    private BallsManager _ballsManager;


    [Inject]
    private void Construct(BallsManager ballsManager)
    {
        _ballsManager = ballsManager;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        _ballsManager.RemoveBall(other.gameObject);
    }
}
