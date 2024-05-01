using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    private const string MasterChannelName = "MasterVolume";
    private const float MinSoundValue = -80f;
    
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Button _button;
    private float _lastMasterVolume = 1f;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleSound);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleSound);
    }

    public void ToggleSound()
    {
        _mixerGroup.audioMixer.GetFloat(MasterChannelName, out float currentMasterVolume);
        if (Mathf.Approximately(currentMasterVolume,MinSoundValue))
        {
            _mixerGroup.audioMixer.SetFloat(MasterChannelName, _lastMasterVolume);
        }
        else
        {
            _lastMasterVolume = currentMasterVolume;
            _mixerGroup.audioMixer.SetFloat(MasterChannelName, MinSoundValue);
        }
    }
}
