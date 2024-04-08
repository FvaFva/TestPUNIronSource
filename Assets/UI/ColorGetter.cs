using UnityEngine;
using UnityEngine.UI;

public class ColorGetter : MonoBehaviour
{
    [SerializeField] private Slider _red;
    [SerializeField] private Slider _green;
    [SerializeField] private Slider _blue;
    [SerializeField] private MeshRenderer _showcase;

    public Color Result { get; private set; }

    private void Awake()
    {
        Result = _showcase.material.color;
        _red.value = Result.r;
        _green.value = Result.g;
        _blue.value = Result.b;
        _red.onValueChanged.AddListener(OnComponentChange);
        _green.onValueChanged.AddListener(OnComponentChange);
        _blue.onValueChanged.AddListener(OnComponentChange);
    }

    private void OnComponentChange(float temp)
    {
        Color color = Color.white;
        color.r = _red.value;
        color.g = _green.value;
        color.b = _blue.value;
        _showcase.material.color = color;
        Result = _showcase.material.color;
    }
}
