using Sandbox;

public sealed class ExplosionDelete : Component
{
	public float LifeSpan = 5f;
	protected override void OnUpdate()
	{
		LifeSpan -= Time.Delta;
		if(LifeSpan <= 0) {
			GameObject.Destroy();
		}
	}
}
