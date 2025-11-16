using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text desc;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private Button playButton;

    public CardData Data { get; private set; }
    private System.Action<CardData> onPlay;

    public void Bind(CardData data, System.Action<CardData> onPlay)
    {
        Data = data;
        this.onPlay = onPlay;

        if (title) title.text = data.cardName;
        if (desc)  desc.text  = data.description;
        if (cost)  cost.text  = data.cost.ToString();

        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() => this.onPlay?.Invoke(data));
        }
    }
}

