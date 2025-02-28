using Sandbox;

public partial class PlayerTank : Component
{
    [Property] public float Speed = 10;
    
    protected override void OnUpdate()
    {
        TankMovement();
    }
    
    void TankMovement()
    {
        if(Input.Down("Forward")) 
        {
            LocalPosition += Vector3.Forward * Speed * Time.Delta;
        }

        if(Input.Down("Backward"))
        {
            LocalPosition += Vector3.Backward * Speed * Time.Delta;
        }

        
    }
}