using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;//interacting with scene change
using UnityEngine.UI;//interacting with GUI elements
using UnityEngine.EventSystems;//control the event (button shiz)

public class W3_MenuHandler : MonoBehaviour
{
    #region Variables
    public GameObject mainMenu, optionsMenu;
    public bool showOptions;
    public Slider volSlider, brightSlider;
    public AudioSource mainAudio;
    public Light dirLight;
    #endregion
    void Start()
    {
        mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleOptions()
    {
        OptionToggle();
    }
    bool OptionToggle()
    {
        if (showOptions)//showOptions == true means showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return true;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();
            volSlider.value = mainAudio.volume;
            return false;
        }
    }
    public void Volume()
    {
        mainAudio.volume = volSlider.value;
    }
    public void Brightness()
    {

    }
}
