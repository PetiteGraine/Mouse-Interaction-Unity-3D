using UnityEngine;

public class DragCube2 : MonoBehaviour
{
    private Vector3 _offset;
    private float _zCoord;
    private Rigidbody _rb;
     private bool _cubeClicked = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _rb.useGravity = false;
        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        _offset = transform.position - GetMouseWorldPosition();
        if (!_cubeClicked) {
            _cubeClicked = true;
           Data.Instance.CubeInteracted++;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 targetPos = GetMouseWorldPosition() + _offset;
        _rb.MovePosition(targetPos);
    }

    private void OnMouseUp()
    {
        _rb.useGravity = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
