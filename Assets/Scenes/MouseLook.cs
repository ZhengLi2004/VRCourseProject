using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Tooltip("鼠标灵敏度")]
    public float mouseSensitivity = 100f;

    [Tooltip("摄像机垂直旋转限制")]
    public float minX = -90f;
    public float maxX = 90f;

    private float xRotation = 0f;

    void Start()
    {
        // 隐藏并锁定鼠标到屏幕中央
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 读取鼠标移动
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 垂直看向（上下）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 水平转头（左右），通过旋转父物体Player来完成
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}