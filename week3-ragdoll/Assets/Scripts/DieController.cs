using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(RagdollController))]
public class DieController : MonoBehaviour
{
    public float DieExplostionForce = 50000;
    public float DieExplostionRadius = 300;
    public float DieUpliftModifier = 0.2f;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Monster")
        {
            var r = this.GetComponent<RagdollController>();
            var go = r.DoRagdoll();
            var rigid = go.transform.FindDeep("body").GetComponent<Rigidbody2D>();

            rigid.AddExplosionForce(
                this.DieExplostionForce,
                c.collider.transform.position, 
                this.DieExplostionRadius,
                this.DieUpliftModifier);
        }
    }
}
