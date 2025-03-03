using Sandbox;

public sealed class TankTurret : Component
{
	protected override void OnUpdate()
	{
		SceneTraceResult traceResult = Scene.Trace.Ray(PlayerCamera.Camera.ScreenPixelToRay(Mouse.Position), 10000f).Run();
		Vector3 lookPos = traceResult.HitPosition;
		lookPos.z = 0;
		WorldRotation = Rotation.LookAt(lookPos);
		WorldRotation = Rotation.From(WorldRotation.Pitch(), WorldRotation.Yaw() - 90, WorldRotation.Roll());
	}
}