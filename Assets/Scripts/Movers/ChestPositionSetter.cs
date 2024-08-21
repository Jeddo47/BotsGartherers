using UnityEngine;

public class ChestPositionSetter : MonoBehaviour 
{
    [SerializeField] private float _positionYWhenTaken;

    public void AssignToAWorker(WorkerMover worker) 
    {
        transform.SetParent(worker.transform);
        transform.rotation = worker.transform.rotation;
        transform.position = new Vector3(transform.position.x, _positionYWhenTaken, transform.position.z);
    }

    public void UnassignFromAWorker() 
    {
        transform.SetParent(null);    
    }
}
