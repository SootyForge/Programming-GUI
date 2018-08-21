using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;//interacting with scene change
using UnityEngine.UI;//interacting with GUI elements
using UnityEngine.EventSystems;//control the event (button shiz)

public class W4_MenuHandler : MonoBehaviour
{
    #region Variables
    public GameObject mainMenu, optionsMenu;
    public bool showOptions;

    public Slider volSlider, brightSlider, ambLightSlider;
    public AudioSource mainAudio;
    public Light dirLight;
    public Dropdown resDropDown;
    public Vector2[] res = new Vector2[7];
    public int resIndex;
    public bool isFullscreen;
    #endregion
    void Start()
    {
        mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
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

            volSlider = GameObject.Find("Slider (Volume)").GetComponent<Slider>();
            volSlider.value = mainAudio.volume;

            brightSlider = GameObject.Find("Slider (Brightness)").GetComponent<Slider>();
            brightSlider.value = dirLight.intensity;

            ambLightSlider = GameObject.Find("Slider (Ambient Light)").GetComponent<Slider>();
            ambLightSlider.value = RenderSettings.ambientIntensity;

            resDropDown = GameObject.Find("Dropdown (Resolution)").GetComponent<Dropdown>();
            return false;
        }
    }
    public void Volume()
    {
        mainAudio.volume = volSlider.value;
    }
    public void Brightness()
    {
        dirLight.intensity = brightSlider.value;
    }

    public void Ambient()
    {
        RenderSettings.ambientIntensity = ambLightSlider.value;
    }

    public void Resolution()
    {
        resIndex = resDropDown.value;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullscreen);
    }
}
