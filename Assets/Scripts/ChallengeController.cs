using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    public float ScrollSpeed = 5.0f;
    public GameObject[] Challenges;
    public float Frequency = 0.5f;
    private float _counter = 0.5f;
    public Transform ChallengeSpwanPoint;

    // Use this for initialization
    void Start()
    {
        GenerateRandomChallenge();
    }

    // Update is called once per frame
    void Update()
    {
        // Generate Object
        if (_counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
        {
            _counter -= Time.deltaTime * Frequency;
        }


        // scrolling
        for (int i = 0; i < transform.childCount; i++)
        {
            var currentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(currentChild);
            if (currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (ScrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        Instantiate(Challenges[Random.Range(0, Challenges.Length)], ChallengeSpwanPoint.position, Quaternion.identity);
        _counter = 1.0f;
    }
}