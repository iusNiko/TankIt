using Sandbox;

public partial class PlayerTank : Component
{
    [Property] public float Speed = 30;
    [Property] public float RotationSpeed = 20;
    [Property] public GameObject Barrel;
    [Property] public GameObject Bullet;
    [Property] public float Cooldown = 0.5f;

    private float timeSinceLastShot;

     protected override void OnStart()
    {
        timeSinceLastShot = Cooldown;
    }

    protected override void OnUpdate()
    {
        TankShoot();
        TankMovement();
    }
    
    void TankShoot()
    {
        timeSinceLastShot += Time.Delta;
        
        if(Input.Pressed("attack1") && timeSinceLastShot >= Cooldown)
        {
            GameObject bullet = Bullet.Clone(Barrel.WorldPosition);
            bullet.LocalRotation = LocalRotation;
            timeSinceLastShot = 0;

        }
    }
    
    void TankMovement()
    {
        if(Input.Down("Forward")) 
        {
            LocalPosition += LocalRotation.Forward * Speed * Time.Delta;
        }

        if(Input.Down("Backward"))
        {
            LocalPosition += LocalRotation.Backward * Speed * Time.Delta;
        }

        if(Input.Down("Left"))
        {
            LocalRotation = Rotation.From(LocalRotation.Pitch(),LocalRotation.Yaw() + (RotationSpeed * Time.Delta), LocalRotation.Roll());
        }

        if(Input.Down("Right"))
        {
            LocalRotation = Rotation.From(LocalRotation.Pitch(),LocalRotation.Yaw() - (RotationSpeed * Time.Delta), LocalRotation.Roll());
        }

    }
    
}
