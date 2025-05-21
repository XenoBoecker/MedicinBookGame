using System.Linq;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float realSecondsPerGameDay = 60f;

    public int CurrentDay { get; private set; } = 1;
    public int CurrentWeek => (CurrentDay - 1) / 7 + 1;

    private float dayTimer = 0f;

    private void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer >= realSecondsPerGameDay)
        {
            dayTimer -= realSecondsPerGameDay;
            AdvanceDay();
        }
    }

    private void AdvanceDay()
    {
        CurrentDay++;
        Debug.Log($"📅 New Day: {CurrentDay} (Week {CurrentWeek})");
    }
}
