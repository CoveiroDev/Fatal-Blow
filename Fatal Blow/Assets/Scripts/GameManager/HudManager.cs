using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("Message")]
    [SerializeField] private Text textMessage;
    [SerializeField] private GameObject messageCanvas;

    [Header("Health")]
    [SerializeField] public GameObject healthCanvas;

    #region Right
    [Header("Right Status")]
    [SerializeField] private Status statusRight;
    [SerializeField] private TextMeshProUGUI nameTextRight;

    [Header("Right Health")]
    [SerializeField] private Slider healthSliderRight;
    [SerializeField] private Slider secondaryHealthSliderRight;
    #endregion
    #region Left
    [Header("Left Status")]
    [SerializeField] private Status statusLeft;
    [SerializeField] private TextMeshProUGUI nameTextLeft;

    [Header("Left Health")]
    [SerializeField] private Slider healthSliderLeft;
    [SerializeField] private Slider secondaryHealthSliderLeft;
    #endregion

    private float animationDuration = 0.5f;

    public void SetFighters(Status LeftPlayer, Status RightPlayer)
    {
        statusRight = RightPlayer;
        statusLeft = LeftPlayer;
        #region Right
        nameTextRight.text = statusRight.Name;

        healthSliderRight.maxValue = statusRight.maxHealth;
        healthSliderRight.value = statusRight.currentHealth;

        secondaryHealthSliderRight.maxValue = statusRight.maxHealth;
        secondaryHealthSliderRight.value = statusRight.currentHealth;
        #endregion
        #region Left
        nameTextLeft.text = statusLeft.Name;

        healthSliderLeft.maxValue = statusLeft.maxHealth;
        healthSliderLeft.value = statusLeft.currentHealth;

        secondaryHealthSliderLeft.maxValue = statusLeft.maxHealth;
        secondaryHealthSliderLeft.value = statusLeft.currentHealth;
        #endregion
    }
    public void ChangeHealthSlide()
    {
        #region Right
        healthSliderRight.value = statusRight.currentHealth;
        StartCoroutine(AnimateSecondaryHealthSlideRight(statusRight.currentHealth, animationDuration));
        #endregion
        #region Left
        healthSliderLeft.value = statusLeft.currentHealth;
        StartCoroutine(AnimateSecondaryHealthSlideLeft(statusLeft.currentHealth, animationDuration));
        #endregion
    }
    #region Right
    private IEnumerator AnimateSecondaryHealthSlideRight(int targetValue, float duration)
    {
        float startTime = Time.time;
        float startValue = secondaryHealthSliderRight.value;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float elapsed = Time.time - startTime;
            float t = Mathf.Clamp01(elapsed / duration);

            secondaryHealthSliderRight.value = Mathf.Lerp(startValue, targetValue, t);

            yield return null;
        }

        secondaryHealthSliderRight.value = targetValue;
    }
    #endregion
    #region Left
    private IEnumerator AnimateSecondaryHealthSlideLeft(int targetValue, float duration)
    {
        float startTime = Time.time;
        float startValue = secondaryHealthSliderLeft.value;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float elapsed = Time.time - startTime;
            float t = Mathf.Clamp01(elapsed / duration);

            secondaryHealthSliderLeft.value = Mathf.Lerp(startValue, targetValue, t);

            yield return null;
        }

        secondaryHealthSliderLeft.value = targetValue;
    }
    #endregion
    public void ShowMessage(string Message)
    {
        textMessage.text = Message;
        messageCanvas.SetActive(true);
    }
    public void HideMessage()
    {
        messageCanvas.SetActive(false);
    }
}
