using Sandbox;

public partial class PlayerTank : Component
{
    [Property] public float MaxSpeed = 500;
    [Property] public float Acceleration = 200;
    [Property] public float Deceleration = 400;
    [Property] public float RotationSpeed = 20;
    [Property] public GameObject Barrel;
    [Property] public GameObject Bullet;
    [Property] public float Cooldown = 0.5f;
    public float CurrentSpeed = 0;

    private float timeSinceLastShot;

     protected override void OnStart()
    {
        Mouse.Visible = true;
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
            bullet.WorldRotation = Rotation.From(Barrel.WorldRotation.Pitch(), Barrel.WorldRotation.Yaw() + 90, Barrel.WorldRotation.Roll());
            timeSinceLastShot = 0;
        }
    }
    
    void TankMovement()
    {
        if(Input.Down("Forward")) 
        {
            if(CurrentSpeed > 0) {
                CurrentSpeed += Acceleration * Time.Delta;
            }
            else {
                CurrentSpeed += Deceleration * Time.Delta;
            }
            
        }
        else if(Input.Down("Backward"))
        {
            if(CurrentSpeed < 0) {
                CurrentSpeed -= Acceleration * Time.Delta;
            }
            else {
                CurrentSpeed -= Deceleration * Time.Delta;
            }
        }
        else {
            if(CurrentSpeed > 0) {
                CurrentSpeed -= Acceleration * Time.Delta;
                if(CurrentSpeed < 0) {
                    CurrentSpeed = 0;
                }
            }
            else if(CurrentSpeed < 0) {
                CurrentSpeed += Acceleration * Time.Delta;
                if(CurrentSpeed > 0) {
                    CurrentSpeed = 0;
                }
            }
        }

        if(CurrentSpeed > MaxSpeed) {
            CurrentSpeed = MaxSpeed;
        }

        LocalPosition += LocalRotation.Left * CurrentSpeed * Time.Delta;

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
