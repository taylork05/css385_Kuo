using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField]
    private float _movespeed = 10f;

    [SerializeField]
    private float _minX = -15f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _movespeed * Time.deltaTime;

        if(transform.position.x <= _minX)
        {
            Destroy(gameObject);
        }
    }
}
