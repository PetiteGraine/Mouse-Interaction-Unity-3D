using UnityEngine;

public class ObjectClick : MonoBehaviour
{
 public float Force = 5;
 public Animator Anim;
 private bool _isOpen = false;

 private void Update() {
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit)) {
        var selection = hit.transform;
        var rig = selection.GetComponent<Rigidbody>();

    if (hit.collider.gameObject.name == "Cube1") {
            if (Input.GetMouseButton(0)) {
                rig.AddForce(Camera.main.transform.forward * 10);
            }
        }

    if (hit.collider.gameObject.name == "Cube") {
            if (Input.GetMouseButton(0)) {
                rig.AddForce(rig.transform.up, ForceMode.Impulse);
            }
        }

    if (hit.collider.gameObject.name == "Door") {
        if (Input.GetMouseButtonDown(0)) {
            Manage();
        }
    }
    }
 }
 public void Manage () {
    if (_isOpen) {
        Anim.Play("DoorClose");
        _isOpen = false;
    }
    else {
        Anim.Play("DoorOpen");
        _isOpen = true;
    }
 }
}
