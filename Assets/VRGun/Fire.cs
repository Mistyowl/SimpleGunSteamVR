using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour
{
    private Interactable interactable;
    public SteamVR_Action_Boolean fireAction;
    public Transform barel;
    public ParticleSystem muzleFlash;
    public int damage = 1;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            if (fireAction[hand].stateDown)
            {
                Debug.Log("переход в стрельбу");
                Firee();
            }
        }
    }

    private void Firee()
    {
        muzleFlash.Play();
        StartCoroutine(Delayss());

    }

    private IEnumerator Delayss()
    {

        RaycastHit hit;
        if (Physics.Raycast(barel.position, barel.forward, out hit, 300))
        {
            if (hit.transform.GetComponent<Enemy>())
            {

                hit.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(0.4f);
    }
}
