using UnityEngine;

public class CtrlOctopus : MonoBehaviour
{
    [SerializeField] private int velocidad;
    [SerializeField] private Vector3 posicionFin;
    private Vector3 posicionInicio;
    [SerializeField] bool moviendoAFin;

    public AudioSource colision;
    
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin=true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDestino= (moviendoAFin) ? posicionFin : posicionInicio;

        transform.position=Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);
        float distanciaMinima=0.01f;
        if (Vector3.Distance(transform.position, posicionFin)< distanciaMinima)
        moviendoAFin=false;
        if (Vector3.Distance(transform.position,posicionInicio)< distanciaMinima)
        moviendoAFin=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CtrlJugador>().QuitarVida();
            
        }
    }
}
