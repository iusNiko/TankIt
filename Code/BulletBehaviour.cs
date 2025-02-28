using System;
using Sandbox;

public partial class BulletBehaviour : Component
{
    [Property] public float Velocity = 50;
    [Property] public float Lifespan = 1;
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
		GameObject explosion = Explosion.Clone(WorldPosition);
        SboxUtils.ChangeParticleScale(ref explosion, 0.2f);
	}

	void BulletMovement()
    {
        LocalPosition += LocalRotation.Forward * Velocity * Time.Delta;
    }
}

