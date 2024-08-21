using System;
using UnityEngine;

public class WorkerMover : MonoBehaviour
{
    [SerializeField] private WorkerAnimator _animator;
    [SerializeField] private Castle _castle;
    [SerializeField] private float _moveSpeed;

    private ChestPositionSetter _chestToGarther;
    private bool _isMoving = false;
    private bool _isCarrying = false;

    public static event Action<ChestPositionSetter> ChestCarried;

    private void Update()
    {
        MoveToAChest();
        CarryChest();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ChestPositionSetter>(out _) && collision.gameObject == _chestToGarther.gameObject)
        {
            _chestToGarther.AssignToAWorker(this);

            _isMoving = false;
            _isCarrying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ChestsGartherer>(out ChestsGartherer chestsGartherer)) 
        {
            if(_isCarrying) 
            {
                _chestToGarther.UnassignFromAWorker();
                ChestCarried?.Invoke(_chestToGarther);
                _animator.StopCarryAnimation();
                chestsGartherer.AddWorker(this);
            }            

            _isCarrying = false;            
        }
    }

    public void SetDestinationPoint(ChestPositionSetter chest)
    {
        _chestToGarther = chest;

        _isMoving = true;
    }

    private void MoveToAChest()
    {
        if (_isMoving)
        {
            _animator.RunRunAnimation();

            FollowDestination(_chestToGarther.transform);
        }
    }

    private void CarryChest()
    {
        if (_isCarrying)
        {
            _animator.StopRunAnimation();
            _animator.RunCarryAnimation();

            FollowDestination(_castle.transform);
        }
    }

    private void FollowDestination(Transform destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, _moveSpeed * Time.deltaTime);
        transform.LookAt(destination);
    }
}
