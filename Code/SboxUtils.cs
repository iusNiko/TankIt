using System.Reflection;

public class SboxUtils {
    public static void ChangeParticleScale(ref GameObject particleParent, float scale) {
        foreach(GameObject particleEffect in particleParent.Children) {
            ParticleEffect effect = particleEffect.GetComponent<ParticleEffect>();
            PropertyInfo info = effect.Scale.CurveA.ValueRange.GetType().GetProperty("y");
            info.SetValue(effect.Scale.CurveA.ValueRange, effect.Scale.CurveA.ValueRange.y * scale);
        }
    }
}