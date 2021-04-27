using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Força do pulo.
    public float jumpForce;
    public float playerSpeed;
    Rigidbody rb;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    //Controla a movimentação do personagem.
    /// <summary>
    /// Transforma o axis vertical e horizontal em um vetor de movimentação.
    /// </summary>
    void Movement() {
        float _v = Input.GetAxis("Vertical");
        float _h = Input.GetAxis("Horizontal");

        //Aplica força vertical somente se o player estiver no chão.
        if(_v > 0 && isGrounded) {
            rb.AddForce(new Vector3(0, _v, 0) * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        rb.AddForce(new Vector3(_h, 0, 0) * playerSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }
}
