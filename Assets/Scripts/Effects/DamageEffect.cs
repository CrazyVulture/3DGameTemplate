using UnityEngine.UI;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public Image damageImg;
    float flashSpeed = 5f;
    Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    public void showEffect(bool isDamaged)
    {
        if (isDamaged)
            damageImg.color = flashColor;
        else
            damageImg.color = Color.Lerp(damageImg.color, Color.clear, flashSpeed * Time.deltaTime);
    }
}
