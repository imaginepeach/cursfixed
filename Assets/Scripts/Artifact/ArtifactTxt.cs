using TMPro;
using UnityEngine;

public class ArtifactTxt : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        Global.ArtifactUpdate += UpdateText;
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = $"Артефакты: {Global.Count}/5";
    }
}
