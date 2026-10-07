using UnityEngine;
using UnityEngine.SceneManagement;

public class CtrlJugador : MonoBehaviour
{
    [SerializeField] private int velocidad;
    [SerializeField] private Rigidbody2D fisica;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int fuerzaSalto;
    private Animator animacion;

    void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animacion = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
        if (fisica.linearVelocity.x > 0) spriteRenderer.flipX = false;
        else if (fisica.linearVelocity.x < 0) spriteRenderer.flipX = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        AnimarJugador();
    }

    private void AnimarJugador()
    {
        if (!TocarSuelo()) animacion.Play("JugadorSaltando");
        //Jugador corriendo
        if ((fisica.linearVelocity.x > 1 || fisica.linearVelocity.x < -1) && fisica.linearVelocity.y == 0)
            animacion.Play("JugadorCorriendo");
        //Jugador parado
        else if ((fisica.linearVelocity.x < 1 || fisica.linearVelocity.x > -1) && fisica.linearVelocity.y == 0)
            animacion.Play("JugadorParado");
    }

    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}