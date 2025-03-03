using Sandbox;

public sealed class TankTurret : Component
{
	protected override void OnUpdate()
	{
		Vector3 pos = PlayerCamera.Camera.ScreenToWorld(Mouse.Position);
		
		Vector3 traceStart = pos;
		Vector3 traceDirection;
	}
}