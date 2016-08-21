using UnityEngine;
using System.Collections;

public class TestRagdoll : MonoBehaviour
{
    public float Force = 5000;
    public float Radius = 5000;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouse = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            foreach (var r in this.GetComponentsInChildren<Rigidbody2D>())
            {
                var pos = (Vector2)r.transform.position;
                r.AddExplosionForce(this.Force, mouse, this.Radius);
            }
        }
	}
}
