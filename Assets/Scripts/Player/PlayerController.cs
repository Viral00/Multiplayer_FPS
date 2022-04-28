using UnityEngine;
public class PlayerController 
{
    public PlayerController(PlayerModel m_playerModel, PlayerView m_playerView)
    {
        PlayerModel = m_playerModel;
        PlayerPrefab = m_playerView;
        PlayerPrefab.playerController = this;
    }

    public PlayerModel PlayerModel { get; }
    public PlayerView PlayerPrefab { get; }

    public void GroundCheck(bool isGrounded, Transform groundcheck, LayerMask groundMask)
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, PlayerModel.GroundDistance ,groundMask);
    }

    public void PlayerInput(float horizontal, float vertical, Transform transform, Vector3 moveDirection)
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        moveDirection = transform.forward * vertical + transform.right * horizontal;
    }

    public void PlayerMove(Rigidbody rb, Transform transform, float speed, bool isGrounded, Vector3 moveDirection)
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = PlayerModel.Walk;
        }
        else
        {
            speed = PlayerModel.Speed;
        }

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
        }
    }

    public void Jump(bool isGrounded, Rigidbody rb, Transform transform)
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * PlayerModel.JumpSpeed, ForceMode.Impulse);
        }
    }

    public void ControlDrag(bool isGrounded, Rigidbody rb)
    {
        if (isGrounded)
        {
            rb.drag = PlayerModel.GroundDrag;
        }
        else
        {
            rb.drag = PlayerModel.Airdrag;
        }
    }
}
