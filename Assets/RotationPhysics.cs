using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class RotationPhysics : MonoBehaviour
{
    public int impulseReduction;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Calcula força de torque baseado no ponto de colisão.
    private void OnCollisionStay(Collision other)
    {
        Rigidbody rbOther = other.gameObject.GetComponent<Rigidbody>();
        if (rbOther != null) {
            float b = other.gameObject.transform.position.x - transform.position.x;
            float t = b * rbOther.velocity.y / impulseReduction;
            rbOther.AddTorque(Vector3.forward * t);
        }
    }
}
