using UnityEngine;

public class GroundDetector : MonoBehaviour {

    public Transform Checker;
    public bool Grounded
    {
        get;
        private set;
    }
  
    void Update()
    {
        if (this.Checker != null)
        {
            this.Grounded = Physics2D.Linecast(this.transform.position,
                this.Checker.position,
                LayerMask.GetMask("Ground"));
        }
    }
}