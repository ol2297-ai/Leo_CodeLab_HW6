using UnityEngine;

public class mouse : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = false;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
