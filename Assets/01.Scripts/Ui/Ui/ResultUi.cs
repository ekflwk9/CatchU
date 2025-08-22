using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUi : UiBase
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemTitle;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemPrice;

#if UNITY_EDITOR
    private void Reset()
    {
        itemTitle = this.TryGetChildComponent<TMP_Text>(Str.ItemTitle);
        itemPrice = this.TryGetChildComponent<TMP_Text>(Str.ItemPrice);
        itemName = this.TryGetChildComponent<TMP_Text>(Str.ItemName);
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<ResultUi>(this);
    }

    /// <summary>
    /// 화면에 표시될 아이템 설정
    /// </summary>
    /// <param name="_item"></param>
    public void SetItem(Item _item)
    {
        itemTitle.color = _item.effectColor;
        itemTitle.text = _item.rank;

        icon.sprite = _item.sprite;
        itemName.text = _item.name;
        itemPrice.text = _item.price.ToString("N0");
    }
}
