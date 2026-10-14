using JetBrains.Annotations;
using UnityEngine;

public class CtrlPowerUp : MonoBehaviour
{

    [SerializeField] private int cantidad;
    
    public AudioSource powerUp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CtrlJugador>().IncrementarPuntos(cantidad);
            powerUp.Play();
            Destroy(gameObject);
        }

       
    }



}


