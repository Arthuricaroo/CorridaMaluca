using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidade = 7f;
    [SerializeField] float forcaPulo = 12f;
    [SerializeField] Transform checaChao;
    [SerializeField] float raioChao = 0.15f;
    [SerializeField] LayerMask camadaChao;

    Rigidbody2D rb;
    float entradaX;
    bool pular;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        entradaX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) pular = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(entradaX * velocidade, rb.velocity.y);

        if (pular && NoChao())
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        pular = false;
    }

    bool NoChao() =>
        Physics2D.OverlapCircle(checaChao.position, raioChao, camadaChao);
}