using UnityEngine;
using TMPro;

public class UIContador : MonoBehaviour
{
    public TMP_Text textoContador;

    private static int objetosActivos = 0;
    private static UIContador instancia;

    private void Awake()
    {
        instancia = this; 
        ActualizarTexto();
    }

    public static void ActualizarContador(int cambio)
    {
        objetosActivos += cambio;
        if (instancia != null)
            instancia.ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textoContador.text = "Number Of Bullets: " + objetosActivos;
    }
}

