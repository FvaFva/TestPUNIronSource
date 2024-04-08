using UnityEngine;
using UnityEngine.UI;

public class Vector3Getter : MonoBehaviour
{
    [SerializeField] private Slider _xAxis;
    [SerializeField] private Slider _yAxis;
    [SerializeField] private Slider _zAxis;
    [SerializeField] private Character _showcase;

    public Vector3 Result { get; private set; }

    private void Awake()
    {
        Result = _showcase.transform.localScale;

        _xAxis.value = Result.x;
        _yAxis.value = Result.y;
        _zAxis.value = Result.z;

        _xAxis.onValueChanged.AddListener(OnAxisChange);
        _yAxis.onValueChanged.AddListener(OnAxisChange);
        _zAxis.onValueChanged.AddListener(OnAxisChange);
    }

    private void OnAxisChange(float temp)
    {
        Result = new Vector3(_xAxis.value, _yAxis.value, _zAxis.value);
        _showcase.transform.localScale = Result;
    }
}
