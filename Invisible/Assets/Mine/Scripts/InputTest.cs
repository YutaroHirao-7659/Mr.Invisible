using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class InputTest : MonoBehaviour, IInputHandler,IInputClickHandler,IFocusable,ISourceStateHandler,IHoldHandler,IManipulationHandler,INavigationHandler, ISpeechHandler
{

    public Text displayedText;

	// Use this for initialization
	void Start () {
		
	}

    //IInputHandler
    //押し込み/上げ
    public void OnInputUp(InputEventData eventData)
    {
        displayedText.text = "押し込み";
    }

    public void OnInputDown(InputEventData eventData)
    {
        displayedText.text = "おしあげ";
    }

    //IInputClickHandler
    //タップ
    public void OnInputClicked(InputClickedEventData eventData)
    {
        displayedText.text = "タップ";
    }

    //IFocusable
    //フォーカス
    public void OnFocusEnter()
    {
        displayedText.text = "フォーカス";
    }

    public void OnFocusExit()
    {
        displayedText.text = "視線はずし";
    }

    //ISourceStateHandler
    //手の検出
    public void OnSourceDetected(SourceStateEventData eventData)
    {
        displayedText.text = "手の検出";
    }

    public void OnSourceLost(SourceStateEventData eventData)
    {
        displayedText.text = "手が外れる";
    }

    //IHoldHandler
    //つまみ検出
    public void OnHoldStarted(HoldEventData eventData)
    {
        displayedText.text = "つまみはじめ";
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        displayedText.text = "つまみ中";
    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
        displayedText.text = "つまみ終わり";
    }

    //IManipulationHandler
    //ドラッグ（無制限）
    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        displayedText.text = "manipulation始まり";
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        displayedText.text = "manipulation中\n" +
                             eventData.CumulativeDelta.x + "," + eventData.CumulativeDelta.y + "," + eventData.CumulativeDelta.z;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        displayedText.text = "manipulation終わり";
    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        displayedText.text = "トラッキングが外れた";
    }

    //INavigationHandler
    //ドラッグ（-1～1）
    public void OnNavigationStarted(NavigationEventData eventData)
    {
        //displayedText.text = "navigation始まり";
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        //displayedText.text = "navigation中\n" + eventData.NormalizedOffset.x + "," + eventData.NormalizedOffset.y + "," + eventData.NormalizedOffset.z;
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        //displayedText.text = "navigation終わり";
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        //displayedText.text = "トラッキングが外れた";
    }

    //ISpeachHandler
    //音声認識
    //SpeechInputSourceを任意のオブジェクトにアタッチし、単語を登録する必要がある。
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        displayedText.text = eventData.RecognizedText.ToLower();
    }
}
