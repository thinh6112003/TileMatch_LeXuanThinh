using UnityEngine;

public class ClockManager : Singleton<ClockManager>
{
    public static int time = 0;
    bool play = true;
    public void startClock()
    {
        time = 0;
        play = true;
        addtime();
    }
    public void stopClock()
    {
        play = false;
    }
    public void addtime()
    {
        if (play == false) return;
        time++;
        Invoke(nameof(addtime), 1);
    }
}
