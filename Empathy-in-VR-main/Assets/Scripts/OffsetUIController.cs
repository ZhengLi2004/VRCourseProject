using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

/// <summary>
/// Controls the user interface for adjusting offsets of the VR IK rig.
/// </summary>
public class OffsetUIController : MonoBehaviour
{
    [SerializeField] private Transform targetTransform; // Renamed for clarity, this can be the camera or any transform.
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text valueLabel;

    private float offsetBackingField;
    private string text = "Height";
    private float Offset
    {
        get => offsetBackingField;
        set
        {
            offsetBackingField = value;
            Vector3 position = targetTransform.localPosition;
            position.y = value;
            targetTransform.localPosition = position;
        }
    }

    private void Start()
    {
        Offset = targetTransform.localPosition.y;        
        slider.value = Offset;
        valueLabel.text = $"{text}: {slider.value:F2}";

        slider.onValueChanged.AddListener(_ => UpdateOffset());
    }

    private void UpdateOffset()
    {
        Offset = slider.value;
        valueLabel.text = $"{text}: {slider.value:F2}";
    }
}