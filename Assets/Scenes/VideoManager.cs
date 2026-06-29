using UnityEngine;
using UnityEngine.Video; // Fondamentale per usare il VideoPlayer
using UnityEngine.SceneManagement; // Fondamentale per cambiare scena

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string scenaGameplay = "intro_2"; // Nome della tua scena di gioco

    void Start()
    {
        videoPlayer.Play();
        // Iscriviti all'evento che scatta quando il video finisce
        videoPlayer.loopPointReached += FineVideo;
    }

    void FineVideo(VideoPlayer vp)
    {
        // Carica la scena successiva
        SceneManager.LoadScene(scenaGameplay);
    }
}