using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PrologoManager : MonoBehaviour
{
    public TextMeshProUGUI testoPrologo;
    public AudioSource audioSource; // Per la canzone
    public AudioSource sfxSource;   // NUOVO: Per il suono tastiera
    public float velocitaScrittura = 0.1f;
    public string scenaProssima = "MainMenu";

    [System.Serializable]
    public struct FraseTimed
    {
        public string testo;
        public float tempoAttesa;
    }

    private string[] frasiIniziali = new string[]
    {
        "In un mondo dove la musica stava facendo stare bene le persone...",
        "jazz...",
        "rock...",
        "metal... e altri generi...",
        "Ci fu una band di 4 persone che creò una canzone malvagia."
    };

    private FraseTimed[] frasiCanzone = new FraseTimed[]
    {
        new FraseTimed { testo = "(Musica)", tempoAttesa = 17.5f },
        new FraseTimed { testo = "Mondoooo questa canzone è per te", tempoAttesa = 4.5f },
        new FraseTimed { testo = "(Musica)", tempoAttesa = 2.5f },
        new FraseTimed { testo = "Mondoooo questa canzone è peeer te", tempoAttesa = 5f },
        new FraseTimed { testo = "(Musica)", tempoAttesa = 1.5f },
        new FraseTimed { testo = "Questa canzone andrà su tutte le classifiche,", tempoAttesa = 4f },
        new FraseTimed { testo = "Sarà l'unica cosa che sentire-te.", tempoAttesa = 3.5f },
        new FraseTimed { testo = "Questa è la canzone: Paaatto col Diavolo.", tempoAttesa = 7f }
    };

    void Start()
    {
        testoPrologo.text = "";
        StartCoroutine(SequenzaPrologo());
    }

    IEnumerator SequenzaPrologo()
    {
        // 1. Frasi iniziali (Effetto macchina da scrivere + Suono)
        foreach (string frase in frasiIniziali)
        {
            foreach (char c in frase)
            {
                testoPrologo.text += c;

                // Suona solo se il carattere non è uno spazio (opzionale)
                if (c != ' ' && sfxSource != null)
                {
                    sfxSource.PlayOneShot(sfxSource.clip);
                }

                yield return new WaitForSeconds(velocitaScrittura);
            }
            yield return new WaitForSeconds(1.5f);
            testoPrologo.text = "";
        }

        // 2. Parte la canzone
        if (audioSource != null) audioSource.Play();
     

        // 3. Frasi della canzone
        foreach (FraseTimed ft in frasiCanzone)
        {
            testoPrologo.text = ft.testo;
            yield return new WaitForSeconds(ft.tempoAttesa);
            testoPrologo.text = "";
        }

        SceneManager.LoadScene(scenaProssima);
    }
}