using TMPro;
using UnityEngine;



public class CtrlHuD : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI vidasTxt;
    [SerializeField] TextMeshProUGUI puntuacion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetvidasTxt(int vidas)
    {
        vidasTxt.text = "Vidas : " + vidas;
    }

    public void SetPuntuacion(int puntos){
        puntuacion.text = "Puntuacion : " + puntos;
    }

}
