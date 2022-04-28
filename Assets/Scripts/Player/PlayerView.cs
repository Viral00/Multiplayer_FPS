using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController playerController;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    private float speed;
    private bool grounded;
    private Vector3 movedirection;
    [SerializeField] private Transform groundcheck;
    [SerializeField] LayerMask groundMask;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerController.GroundCheck(grounded, groundcheck, groundMask);
        playerController.PlayerInput(horizontal, vertical, transform, movedirection);
        playerController.ControlDrag(grounded, rb);
        if (Input.GetButton("Jump"))
        {
            playerController.Jump(grounded, rb, transform);
        }
    }

    private void FixedUpdate()
    {   
        playerController.PlayerMove(rb, transform, speed, grounded, movedirection);
    }
}
