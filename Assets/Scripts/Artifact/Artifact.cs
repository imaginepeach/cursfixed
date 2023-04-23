using UnityEngine;

public class Artifact : MonoBehaviour
{
    private void Awake()
    {
        if (Global.ArtifactsPressence.ContainsKey(name)) Destroy(gameObject);
    }

    public void Collected()
    {
        Global.ArtifactsPressence[name] = true;
        Destroy(gameObject);
    }
}
