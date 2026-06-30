using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class Prologo2 : MonoBehaviour
{ 
    public TextMeshProUGUI testoPrologo;
    public AudioSource sfxSource;   // NUOVO: Per il suono tastiera
    public float velocitaScrittura = 0.1f;
    public string scenaProssima = "fine_intro";

    [System.Serializable]
    public struct FraseTimed
    {
        public string testo;
        public float tempoAttesa;
    }

    private string[] frasiIniziali = new string[]
    {
        "Questa bellissima canzone scalò tutte le classifiche",
        "entrando nelle menti di tutti",
        "A scuola insegnano l'alfabeto con questa canzone",
        "i bambini non ascoltano altro",
        "ed è per questo che alcuni si sono stufati... soprattutto...",
        "una persona in particolare non ne potè più."
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
                // Suona solo se il carattere non è uno spazio (opzionale)
                if (c != ' ' && sfxSource != null)
                {
                    sfxSource.PlayOneShot(sfxSource.clip);
                }
                testoPrologo.text += c;



                yield return new WaitForSeconds(velocitaScrittura);
            }
            yield return new WaitForSeconds(1.5f);
            testoPrologo.text = "";
        }

        SceneManager.LoadScene(scenaProssima);
    }
}