using UnityEngine;

public class ChestStats : MonoBehaviour
{
    [SerializeField] private float _chestGoldAmount;

    public float ChestGoldAmount => _chestGoldAmount;
}
