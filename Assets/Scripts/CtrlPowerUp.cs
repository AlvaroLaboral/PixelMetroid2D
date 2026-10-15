using UnityEngine;

public class CtrlPowerUp : MonoBehaviour
{
    [SerializeField] private int cantidad;
    public AudioClip sonidoPowerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CtrlJugador jugador = collision.gameObject.GetComponent<CtrlJugador>();
            jugador.IncrementarPuntos(cantidad);
            jugador.audioSource.PlayOneShot(sonidoPowerUp);
            Destroy(gameObject);
        }
    }
}


