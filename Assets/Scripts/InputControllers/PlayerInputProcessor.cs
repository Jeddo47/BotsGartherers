using UnityEngine;

public class PlayerInputProcessor : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private CameraMover _cameraMover;

    private Vector3 _horizontalAxis = Vector3.right;
    private Vector3 _verticalAxis = Vector3.forward;

    private void FixedUpdate()
    {
        _cameraMover.Move(_horizontalAxis, _playerInputReader.HorizontalDirection);
        _cameraMover.Move(_verticalAxis, _playerInputReader.VerticalDirection);
    }
}
