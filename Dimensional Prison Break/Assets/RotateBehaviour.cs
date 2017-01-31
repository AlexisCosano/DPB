using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour {

    Vector3 movement;
    Animator anim;
    Rigidbody hipRigidbody;
    int floorMask;
    float camRayLength = 100f;
    public GameObject spine;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        //hipRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (anim.GetBool("Attack"))
        {
            Turning();
        }
    }


    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - spine.transform.position;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            Debug.Log("asaa");
            spine.transform.rotation = newRotation;
        }
    }
}
