using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle;

    [SerializeField]
    private float _spawnFreq = 3f;

    private float _timeTillNext = 0f;

    [SerializeField]
    private float _yOffsetMin = 1f, _yOffsetMax = 3f;
    
    [SerializeField]
    private PlayerController _player;

    // Update is called once per frame
    void Update()
    {
        if(_timeTillNext <= 0f && _player.isAlive)
        {
            Vector3 newPosition = new Vector3(transform.position.x, Random.Range(_yOffsetMin, _yOffsetMax));
            Instantiate (_obstacle, newPosition, transform.rotation);
            _timeTillNext = _spawnFreq;
        }
        else
        { 
            _timeTillNext -= Time.deltaTime;
        }
        
    }
}
