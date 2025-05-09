using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Tooltip("���������")]
    public float mouseSensitivity = 100f;

    [Tooltip("�������ֱ��ת����")]
    public float minX = -90f;
    public float maxX = 90f;

    private float xRotation = 0f;

    void Start()
    {
        // ���ز�������굽��Ļ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ��ȡ����ƶ�
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ��ֱ�������£�
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // ˮƽתͷ�����ң���ͨ����ת������Player�����
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}