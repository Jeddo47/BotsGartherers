using System.Collections.Generic;
using UnityEngine;

public class ChestsGartherer : MonoBehaviour
{
    [SerializeField] private ChestSpawner _chestSpawner;
    [SerializeField] private List<WorkerMover> _availableWorkers;

    private List<ChestPositionSetter> _chestsToGarther = new List<ChestPositionSetter>();

    private void OnEnable()
    {
        _chestSpawner.ChestSpawned += AddChest;       
    }

    private void FixedUpdate()
    {
        SendWorkerToAChest();
    }

    private void OnDisable()
    {
        _chestSpawner.ChestSpawned -= AddChest;       
    }

    public void AddWorker(WorkerMover worker) 
    {
        _availableWorkers.Add(worker);           
    }

    private void AddChest(ChestPositionSetter chest) 
    {
        _chestsToGarther.Add(chest);            
    }

    private void SendWorkerToAChest() 
    {
        if (_availableWorkers.Count > 0 && _chestsToGarther.Count > 0)
        {
            _availableWorkers[0].SetDestinationPoint(_chestsToGarther[0]);

            _availableWorkers.RemoveAt(0);
            _chestsToGarther.RemoveAt(0);
        }
    }
}
