using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField] private GameObject whole;
    [SerializeField] private List<GameObject> pieces;
    [SerializeField] private string breakerTag;

    [SerializeField] private AudioSource woodVreakingAS;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var part in pieces)
            part.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.body.gameObject.tag != breakerTag)
            return;

        if (collision.relativeVelocity.magnitude <= 2)
            return;

        whole.SetActive(false);

        foreach(var part in pieces)
            part.SetActive(true);

        woodVreakingAS.Play();
    }
}
