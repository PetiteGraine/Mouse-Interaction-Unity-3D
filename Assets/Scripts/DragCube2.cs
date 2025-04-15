using UnityEngine;

public class DragCube2 : MonoBehaviour
{
    private Vector3 _offset;
    private float _zCoord;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    void OnMouseDown()
    {
        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        _offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 targetPos = GetMouseWorldPosition() + _offset;
        _rb.MovePosition(targetPos);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
