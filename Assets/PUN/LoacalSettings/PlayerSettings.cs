using TMPro;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private ColorGetter _colorGetter;
    [SerializeField] private Vector3Getter _scaleGetter;

    private void Awake()
    {
        _inputName.text = $"Player_{Random.Range(100, 1000)}";
    }

    public string Name => _inputName.text;
    public CharacterSettings CharacterSettings => new CharacterSettings(_colorGetter.Result, _scaleGetter.Result);
}
