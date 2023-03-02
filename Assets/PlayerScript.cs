using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    private Camera _camera;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        if(_camera == null)
        {
            Debug.LogError("Camera is null on the player controller.");
        }
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        if (!Input.GetMouseButton(0)) return;

        RaycastHit hit;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            _agent.destination = hit.point;
        }
    }
}
