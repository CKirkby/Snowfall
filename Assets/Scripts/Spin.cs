using UnityEngine;

public class Spin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up * (50 * Time.deltaTime));
    }
}
