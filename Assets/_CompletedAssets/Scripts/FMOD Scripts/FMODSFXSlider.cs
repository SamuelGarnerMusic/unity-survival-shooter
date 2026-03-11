using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class SFXVolumeSlider : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider slider;

    [Header("Parameter Range (match FMOD Studio)")]
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;

    private const string PARAMETER_NAME = "Level_SFXs";

    void Start()
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;

        slider.onValueChanged.AddListener(OnSliderValueChanged);

        // Apply the initial slider value immediately
        OnSliderValueChanged(slider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        FMOD.RESULT result = RuntimeManager.StudioSystem.setParameterByName(PARAMETER_NAME, value);

        if (result != FMOD.RESULT.OK)
        {
            Debug.LogWarning($"[SFXVolumeSlider] Failed to set '{PARAMETER_NAME}': {result}");
        }
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}