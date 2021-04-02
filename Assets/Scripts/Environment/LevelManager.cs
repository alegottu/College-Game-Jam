using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CheckPoint[] checkPoints = null;
    [SerializeField] private Friend friend = null;
    [SerializeField] private Guardian guardian = null;

    public void Reset() // Return to last checkpoint reached
    {
        
    }
}
