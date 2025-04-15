using Unity.VisualScripting;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    private LineRenderer _beam;
    private Camera _cam;

    private Vector3 _origin;
    private Vector3 _endPoint;
    private Vector3 _mousePos;

    private void Start()
    {
        _beam = gameObject.AddComponent<LineRenderer>();
        _beam.startWidth = 0.1f;
        _beam.endWidth = 0.1f;

        _cam = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            checkLaser();
        }
        else _beam.enabled = false;
    }

    private void checkLaser()
    {
        _origin = transform.position + transform.forward * 0.5f * transform.lossyScale.z;

        _mousePos = Input.mousePosition;
        _mousePos.z = 300f;
        _endPoint = _cam.ScreenToWorldPoint(_mousePos);

        Vector3 dir = _endPoint - _origin;
        dir.Normalize();

        RaycastHit hit;
        if (Physics.Raycast(_origin, dir, out hit, 300f)) {
            _endPoint = hit.point;
        }

        _beam.SetPosition(0, _origin);
        _beam.SetPosition(1, _endPoint);
        _beam.enabled = true;
    }
}
