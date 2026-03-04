using UnityEngine;
using FMODUnity;


public class FMODAnimationTrigger : MonoBehaviour
{
    //[SerializeField]
    //private EventReference animationEventSound;

    void TriggerFmodEvent(string fmodEventPath)
    {
        RuntimeManager.PlayOneShot(fmodEventPath, transform.position);
    }


}
