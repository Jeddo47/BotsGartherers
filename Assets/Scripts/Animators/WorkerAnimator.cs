using UnityEngine;

public class WorkerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _isRunning = "IsRunning";
    private string _isCarrying = "IsCarrying";

    public void RunRunAnimation() 
    {
        _animator.SetBool(_isRunning, true);    
    }

    public void StopRunAnimation() 
    {
        _animator.SetBool(_isRunning, false);
    }

    public void RunCarryAnimation() 
    {
        _animator.SetBool(_isCarrying, true);
    }

    public void StopCarryAnimation() 
    {
        _animator.SetBool(_isCarrying, false);
    }
}
