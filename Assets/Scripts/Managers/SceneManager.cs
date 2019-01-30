using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public AudioClip bgm;
    public AudioClip winSound;

    public static SceneManager Instance=null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
            Instance = this;
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        if (Instance != this)
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        winText.text = "";
        SoundManager.Instance.PlayMusic(bgm);
    }

    public void SetCountText(int count)
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
            SoundManager.Instance.PlayMusic(winSound);
        }
            
    }
}
