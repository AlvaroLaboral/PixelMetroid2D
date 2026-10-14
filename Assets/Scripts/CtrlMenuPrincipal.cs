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


    public void Jugar()
    {
        SceneManager.LoadScene(escenaJuego);
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

   
    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        panelCreditos.SetActive(false);
    }
}