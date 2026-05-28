using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isActivated = false;

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;

            Debug.Log("Lever Activated!");
            
            // contoh:
            // buka pintu
            // matikan trap
        }
    }
}