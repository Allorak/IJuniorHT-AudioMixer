using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _channelName;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float sliderValue)
    {
        _mixerGroup.audioMixer.SetFloat(_channelName, Mathf.Log10(sliderValue) * 20);
    }
}
