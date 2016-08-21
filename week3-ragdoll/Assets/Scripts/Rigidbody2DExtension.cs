using UnityEngine;

public static class Rigidbody2DExtension
{
    public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector2 explosionPosition, float explosionRadius)
    {
        var dir = ((Vector2)body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        if (wearoff > 0)
        {
            body.AddForce(dir.normalized * explosionForce * wearoff);
        }
    }

    public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upliftModifier)
    {
        var dir = ((Vector2)body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);

        if (wearoff > 0)
        {
            Vector3 baseForce = dir.normalized * explosionForce * wearoff;
            body.AddForce(baseForce);

            float upliftWearoff = (1 - upliftModifier) / explosionRadius;
            Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
            body.AddForce(upliftForce);
        }
    }
}
