using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private float _horizontalDirection;
    private float _verticalDirection;

    public float HorizontalDirection => _horizontalDirection;
    public float VerticalDirection => _verticalDirection;

    private void Update()
    {
        ReadCameraMove(ref _horizontalDirection, Horizontal);
        ReadCameraMove(ref _verticalDirection, Vertical);
    }

    private void ReadCameraMove(ref float direction, string axisName) 
    {
        direction = Input.GetAxis(axisName);                    
    }
}
