using Sandbox;

public partial class BulletBehaviour : Component
{
    [Property] public float Velocity = 50;
    [Property] public float Lifespan = 5;
    [Property] public GameObject Explosion;
     
     protected override void OnUpdate()
    {
        BulletMovement();
        Lifespan -= Time.Delta;

        if(Lifespan <= 0)
        {
            GameObject.Destroy();
        }
    }

	protected override void OnDestroy()
	{
		Explosion.Clone(WorldPosition);
	}

	void BulletMovement()
    {
        LocalPosition += LocalRotation.Forward * Velocity * Time.Delta;
    }
}

