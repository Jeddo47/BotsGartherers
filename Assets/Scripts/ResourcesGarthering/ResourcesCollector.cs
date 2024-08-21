using System;
using UnityEngine;

public class ResourcesCollector : MonoBehaviour
{
    private float _currentGold = 0;

    public event Action<float> GoldCountChanged;

    private void OnEnable()
    {
        WorkerMover.ChestCarried += AddGold;        
    }

    private void OnDisable()
    {
        WorkerMover.ChestCarried -= AddGold;
    }

    private void AddGold(ChestPositionSetter chest) 
    {
        _currentGold += chest.GetComponent<ChestStats>().ChestGoldAmount;

        GoldCountChanged?.Invoke(_currentGold);
    }
}
