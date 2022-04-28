
public class PlayerModel
{
    public PlayerModel(float speed, float walk, float jumpSpeed, float groundDrag, float airdrag, float groundDistance)
    {
        Speed = speed;
        Walk = walk;
        JumpSpeed = jumpSpeed;
        GroundDrag = groundDrag;
        Airdrag = airdrag;
        GroundDistance = groundDistance; 
    }

    public float Speed { get; }
    public float Walk { get; }
    public float JumpSpeed { get; }
    public float GroundDrag { get; }
    public float Airdrag { get; }
    public float GroundDistance { get; }
}
