using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private ChestPositionSetter _chest;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _maxChestAmount;
    [SerializeField] private Vector2 _spawnPositionXRange;
    [SerializeField] private Vector2 _spawnPositionZRange;
    [SerializeField] private Vector2 _spawnRotationYRange;

    private ObjectPool<ChestPositionSetter> _pool;

    public event Action<ChestPositionSetter> ChestSpawned; 

    private void Awake()
    {
        _pool = new ObjectPool<ChestPositionSetter>(
            createFunc: () => Instantiate(_chest),
            actionOnGet: OnGet,
            actionOnRelease: (objectType) => objectType.gameObject.SetActive(false),
            actionOnDestroy: OnChestDestroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private void OnEnable()
    {
        WorkerMover.ChestCarried += ReleaseObject;
    }

    private void OnDisable()
    {
        WorkerMover.ChestCarried -= ReleaseObject;
    }

    private void OnGet(ChestPositionSetter chest)
    {
        chest.gameObject.SetActive(true);
        chest.transform.position = new Vector3(UnityEngine.Random.Range(_spawnPositionXRange.x, _spawnPositionXRange.y), 0,
                                               UnityEngine.Random.Range(_spawnPositionZRange.x, _spawnPositionZRange.y));
        chest.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(_spawnRotationYRange.x, _spawnRotationYRange.y), 0));

        ChestSpawned?.Invoke(chest);
    }

    private void GetObject()
    {
        _pool.Get();
    }

    private void ReleaseObject(ChestPositionSetter chest)
    {
        _pool.Release(chest);
    }

    private void OnChestDestroy(ChestPositionSetter chest)
    {
        Destroy(chest.gameObject);
    }

    private IEnumerator StartSpawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            if (_pool.CountActive < _maxChestAmount)
            {
                GetObject();
            }

            yield return wait;
        }
    }
}
