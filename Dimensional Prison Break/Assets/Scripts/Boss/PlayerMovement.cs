using UnityEngine;
using GamepadInput;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 w = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One, true);


        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One))
        {
            anim.SetTrigger("Attack");
        }

        Move(w.x, w.y);
        //Turning();
        Animating(w.x, w.y);
    }

    void Move(float h,float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * -speed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(transform.position + movement);


        if(movement.magnitude > 0.01f)
        {
        Vector3 playerToMouse = movement;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

        playerRigidbody.MoveRotation(Quaternion.Slerp(transform.rotation,newRotation,0.5f));
        }
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h,float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
