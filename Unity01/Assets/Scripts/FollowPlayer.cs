using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3 (0,1,- 5);
    }
}
