using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CtrlJugador : MonoBehaviour
{
    [SerializeField] private int velocidad;
    [SerializeField] private Rigidbody2D fisica;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int fuerzaSalto;
    [SerializeField] int numVidas;
    [SerializeField] private int puntuacion;
    [SerializeField] private string menuPrincipal = "Menu Principal";
    [SerializeField] private GameObject panelFin;
    private Animator animacion;
    private bool vulnerable;
    
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip sonidoFin;

    void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animacion = GetComponentInChildren<Animator>();
        vulnerable = true;
        Time.timeScale=1;
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panelFin.SetActive(true);
        Time.timeScale=0;
        audioSource.PlayOneShot(sonidoFin);
        
    }

    public void QuitarVida()
    {
        if (vulnerable)
        {
            audioSource.PlayOneShot(audioClip);
            vulnerable = false;
            numVidas--;
            if (numVidas == 0)
                FinJuego();
            Invoke("HacerVulnerable", 1f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    private void HacerVulnerable()
    {
        vulnerable=true;
        spriteRenderer.color=Color.white;
    }

    public void IncrementarPuntos(int puntos)
    {
        puntuacion += puntos;
    }

    public void Menu()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(menuPrincipal);

    }
}