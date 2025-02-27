
public sealed class MyComponent : Component
{
	[Property] public string StringProperty { get; set; }

	protected override void OnUpdate()
	{
		if(Input.Pressed("attack1")) {
			Log.Info("kliknąłeś w myszkę!");
		}
	}
}
