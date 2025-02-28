using Sandbox;

public class SboxUtils {
    public static void ChangeParticleScale(ref GameObject particleParent, float scale) {
        foreach(GameObject particleEffect in particleParent.Children) {
            ParticleEffect effect = particleEffect.GetComponent<ParticleEffect>();
            ParticleFloat e_scale = effect.Scale;
            Curve e_curve = e_scale.CurveA;
            Vector2 e_valueRange = e_curve.ValueRange;
            e_valueRange.y *= scale;
            e_curve.ValueRange = e_valueRange;
            e_scale.CurveA = e_curve;
            effect.Scale = e_scale;

            ParticleFloat e_startVelocity = effect.StartVelocity;
            e_startVelocity.ConstantA *= scale;
            e_startVelocity.ConstantB *= scale;
            effect.StartVelocity = e_startVelocity;

            effect.LocalScale = effect.LocalScale * scale;
        }
    }
}
