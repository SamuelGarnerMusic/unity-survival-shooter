using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;

    // Set this to your VCA path in FMOD Studio e.g. "vca:/Music"
    private FMOD.Studio.VCA musicVCA;

    void Start()
    {
        musicVCA = RuntimeManager.GetVCA("vca:/Music");

        // Load saved volume or default to 1
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        musicSlider.value = savedVolume;
        musicVCA.setVolume(savedVolume);

        // Listen for slider changes
        musicSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        musicVCA.setVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    void OnDestroy()
    {
        musicSlider.onValueChanged.RemoveListener(OnSliderChanged);
    }
}