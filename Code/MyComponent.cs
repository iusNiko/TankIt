
public sealed class MyComponent : Component
{
	[Property] public string StringProperty { get; set; }

	protected override void OnUpdate()
	{
		if(Input.Pressed("attack1")) {
			Log.Info("do dupy se kliknij");
			Log.Error("Error: User can't");
		}
	}
}
