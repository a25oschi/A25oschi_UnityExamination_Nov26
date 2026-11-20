using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PitchSliderController : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer audioMixer; // Assign MainMixer in Inspector
    public string pitchParameterName = "MusicPitch"; // Must match exposed name

    [Header("UI")]
    public Slider pitchSlider; // Assign Slider in Inspector

    void Start()
    {
        // Ensure slider is initialized correctly
        if (pitchSlider != null)
        {
            pitchSlider.onValueChanged.AddListener(SetPitch);
            float currentPitch;
            if (audioMixer.GetFloat(pitchParameterName, out currentPitch))
            {
                pitchSlider.value = currentPitch;
            }
            else
            {
                pitchSlider.value = 1.0f; // Default pitch
            }
        }
    }

    /// <summary>
    /// Called when slider value changes.
    /// </summary>
    /// <param name="value">Pitch value (0.5 to 2.0)</param>
    public void SetPitch(float value)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat(pitchParameterName, value);
        }
    }
}