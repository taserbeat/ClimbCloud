using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
