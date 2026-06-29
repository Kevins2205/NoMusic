using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CaricaNuovaPartita()
    {
        // Carica direttamente la scena della cinematica
        SceneManager.LoadScene("intro");
    }
    public void EsciDalGioco()
    {
        Debug.Log("La musica sta tornando 🎵🎵🎵..."); // Questo vedrai nella Console dell'Editor

#if UNITY_EDITOR
        // Questo ferma la riproduzione nell'Editor di Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Questo chiude il gioco quando è un eseguibile .exe
        Application.Quit();
#endif
    }
}
