using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yomiage.SDK;
using Yomiage.SDK.Config;
using Yomiage.SDK.Settings;
using Yomiage.SDK.Talk;
using Yomiage.SDK.VoiceEffects;

namespace SimpleEngine
{
    public class VoiceEngine : VoiceEngineBase
    {

        public override async Task<double[]> Play(VoiceConfig voicePreset, VoiceConfig subPreset, TalkScript talkScript, MasterEffectValue masterEffect, Action<int> setSamplingRate_Hz, Action<double[]> submitWavePart)
        {
            StateText = "再生されました。";
            if (IsPlaying) { return null; }
            IsPlaying = true;
            StopFlag = false;

            setSamplingRate_Hz(44100);
            if (!voicePreset.Library.TryGetValue("", "", out double[] wave))
            {
                wave = new double[0];
            }

            IsPlaying = false;
            StopFlag = false;
            return wave;
        }

    }
}
