using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    public CameraMovement cameraMov;
    [Space]
    public Transform player;
    [Space]
    public float speed;

    public void Update()
    {
        transform.position = new Vector3(player.transform.position.x + cameraMov.offset.x, 0, 0);

        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
