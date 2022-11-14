using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpCtrPanel : MonoBehaviour
{
    public int participantNumber;
    public int blockNumber;
    public PinchSlider ParticipantSlider;
    public PinchSlider BlockSlider;
    public TextMeshPro ParticipantNumText;
    public TextMeshPro BlockNumText;


    private void Start()
    {
        ParticipantNumText.text = ((int)Math.Round(ParticipantSlider.SliderValue * 5 + 1)).ToString();
        BlockNumText.text = ((int)Math.Round(BlockSlider.SliderValue * 5 + 1)).ToString();
    }

    public void SliderValuetoParticipantNum()
    {
        int temp;
        temp = (int)Math.Round(ParticipantSlider.SliderValue * 5 + 1);
        if (temp != participantNumber)
        {
            participantNumber = temp;
            ParticipantNumText.text = participantNumber.ToString();
        }
    }

    public void SliderValuetoBlockNum()
    {
        int temp;
        temp = (int)Math.Round(BlockSlider.SliderValue * 5 + 1);
        if (temp != blockNumber)
        {
            blockNumber = temp;
            BlockNumText.text = blockNumber.ToString();
        }
    }
}
