using UnityEngine;

public class PlayerPrefsUtility : MonoBehaviour
{
    // This adds a right‑click option in the Inspector
    [ContextMenu("Clear PlayerPrefs")]
    private void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs cleared.");
    }
}
