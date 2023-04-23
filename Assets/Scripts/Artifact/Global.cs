using System.Collections.Generic;

public static class Global
{
    public delegate void artifactUpdate();
    public static event artifactUpdate ArtifactUpdate;
    public static int Count;

    public static Dictionary<string, bool> ArtifactsPressence = new Dictionary<string, bool>();

    public static void ArtifactUpdateCall()
    {
        ArtifactUpdate?.Invoke(); 
    }
}
