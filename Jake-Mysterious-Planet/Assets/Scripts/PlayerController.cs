using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse button clicked!");
        }
    }
}