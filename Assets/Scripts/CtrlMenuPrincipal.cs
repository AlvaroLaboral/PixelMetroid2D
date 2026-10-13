using UnityEngine;
using UnityEngine.SceneManagement;

public class CtrlMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private string escenaJuego = "Nivel 1";

    void Start()
    {
        panelCreditos.SetActive(false);
    }

    //Botón Jugar: carga la escena del juego
    public void Jugar()
    {
        SceneManager.LoadScene(escenaJuego);
    }

    //Botón Salir: cierra el juego
    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    //Botón Créditos: muestra el panel
    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    //Botón Volver: oculta el panel
    public void OcultarCreditos()
    {
        panelCreditos.SetActive(false);
    }
}