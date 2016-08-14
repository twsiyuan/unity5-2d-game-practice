using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    public float MaxSpeed = 20;
    public float MoveForce = 356;

    public float JumpForce = 100;

    bool jumpFlag = false;

    void Update()
    {
        var speed = Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x);
        var gounded = this.GetComponent<GroundDetector>().Grounded;
        if (Input.GetButtonDown("Jump") && gounded)
        {
            this.jumpFlag = true;
        }

        var anim = this.GetComponent<Animator>();
        anim.SetBool("Grounded", gounded);
        anim.SetBool("Walk", speed > 0);
        anim.SetFloat("Speed", Mathf.InverseLerp(0, this.MaxSpeed, speed));
    }

	void FixedUpdate()
    {
        var dir = Input.GetAxis("Horizontal");
        var r = this.GetComponent<Rigidbody2D>();
        if (r.velocity.x * dir < this.MaxSpeed)
        {
            r.AddForce(Vector2.right * this.MoveForce * dir);
        }

        if (Mathf.Abs(r.velocity.x) > this.MaxSpeed)
        {
            r.velocity = new Vector2(Mathf.Sign(r.velocity.x) * this.MaxSpeed, r.velocity.y);
        }

        if (this.transform.localScale.x * dir < 0)
        {
            this.Flip();
        }

        if (this.jumpFlag)
        {
            r.AddForce(Vector2.up * this.JumpForce);
            this.jumpFlag = false;
        }
   }

    void Flip()
    {
        var s = this.transform.localScale;
        s.x *= -1;
        this.transform.localScale = s;
    }
}