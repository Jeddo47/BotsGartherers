using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public void Move(Vector3 axis, float direction) 
    {
        transform.Translate(axis * direction * _moveSpeed * Time.deltaTime, Space.World);                    
    }
}
