using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class CircleHandler : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] SpriteRenderer _circleSpriteRenderer;
    [SerializeField] Animator _circleAnim;

    private WaitForSecondsRealtime waitForTriggerReset;
    [SerializeField] float waitForTriggerResetTime;


    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        waitForTriggerReset = new WaitForSecondsRealtime(waitForTriggerResetTime);
    }
    private void RandomColor()
    {
        _circleSpriteRenderer.material.color = Random.ColorHSV(0f, 1f, 0.1f, 1f, 0.1f, 1f);
    }

    private void PlayCircleAnimation()
    {
        _director.Play();
        _circleAnim.SetTrigger("IsMove");
    }

    public void StartTimeline()
    {
        StartCoroutine(ControlCircle());
    }
    IEnumerator ControlCircle()
    {
        RandomColor();
        PlayCircleAnimation();
        yield return waitForTriggerReset;
        _circleAnim.ResetTrigger("IsMove");
    }
}