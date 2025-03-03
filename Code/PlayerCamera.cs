using Sandbox;

public partial class PlayerCamera : Component {
    public static CameraComponent Camera;

	protected override void OnStart()
	{
		Camera = GetComponent<CameraComponent>();
	}
}