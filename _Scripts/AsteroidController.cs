using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    private float _speed;
    private Transform _transform;

    public GameObject explosionParticle;
    public GameController gameController;

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        _speed = 0.15f;
        _transform = GetComponent<Transform>();

        _reset();
    }

    // Update is called once per frame
    void Update()
    {
        _move();
        _checkBounds();
    }

    private void _checkBounds()
    {
        if (_transform.position.x < -29f)
        {
            _reset();
        }
    }

    private void _move()
    {
        Vector2 newPos = _transform.position;

        newPos.x -= Speed;

        _transform.position = newPos;
    }

    private void _reset()
    {
        _transform.position = new Vector2(Random.Range(-13f, -15.04f) , Random.Range(3.8f, -4.04f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            gameController.ScoreValue += 100;
            Instantiate(explosionParticle, gameObject.transform.position, gameObject.transform.rotation);
            _reset();
        }
    }
}
