using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI testoDialogo;
    public GameObject pannelloDialogo;
    public GameObject iconaContinua; // <--- TRASCINA QUI IL TRIANGOLINO
    public GameObject scrittaContinua;
    public AudioSource sfxSource;
    public float velocitaScrittura = 0.05f;
    [TextArea(3, 10)]
    public string[] frasi;
    public string scenaProssima = "fine_prologo";

    private bool inAttesaDiInput = false;

    void Start()
    {
        pannelloDialogo.SetActive(true);
        if (iconaContinua != null) iconaContinua.SetActive(false); // Parte spento
        if(scrittaContinua != null) scrittaContinua.SetActive(false); // Parte spento 
        StartCoroutine(MostraDialoghi());
    }

    IEnumerator MostraDialoghi()
    {
        foreach (string frase in frasi)
        {
            testoDialogo.text = ""; // Pulisci prima di scrivere

            // Scrittura frase
            foreach (char c in frase)
            {
                if (c != ' ' && sfxSource != null) sfxSource.PlayOneShot(sfxSource.clip);
                testoDialogo.text += c;
                yield return new WaitForSeconds(velocitaScrittura);
            }

            // Appare l'icona quando la frase è finita
            if (iconaContinua != null) iconaContinua.SetActive(true);
            if (scrittaContinua != null) scrittaContinua.SetActive(true);
            inAttesaDiInput = true;
            while (inAttesaDiInput)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    inAttesaDiInput = false;
                }
                yield return null;
            }

            // Nascondi icona prima di passare alla prossima frase
            if (iconaContinua != null) iconaContinua.SetActive(false);
            if (scrittaContinua != null) scrittaContinua.SetActive(false);
            testoDialogo.text = "";
        }

        pannelloDialogo.SetActive(false);
        SceneManager.LoadScene(scenaProssima);
    }
}