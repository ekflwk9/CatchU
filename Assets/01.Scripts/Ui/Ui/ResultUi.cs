using Unity.VisualScripting;
using UnityEngine;

public class ResultUi : UiBase
{
    public override void Init()
    {
        UiManager.Instance.Add<ResultUi>(this);
    }
}
