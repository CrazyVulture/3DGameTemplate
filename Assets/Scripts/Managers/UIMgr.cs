using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public Text countText;
    public Text winText;

    void Start()
    {
        UIInit();
    }

    //UI Init
    private void UIInit()
    {
        winText.text = "";
    }

    public void SetCountText(int count)
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
        }
    }

}
