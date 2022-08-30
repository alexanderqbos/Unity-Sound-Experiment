using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private Camera cam;    // reference to the camera (for shooting a ray into 3D world)

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))   // does the ray intersect with any world colliders
            {
                Debug.Log("clicked: " + hit.point);
                agent.SetDestination(hit.point);    // set the agent's destination to the ray's hit point.
            }
        }   
    }


    void Start()
    {
        //agent.SetDestination(Vector3.zero);  // go to [0,0,0]   
    }

}
