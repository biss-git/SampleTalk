using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yomiage.SDK;
using Yomiage.SDK.Talk;
using Yomiage.SDK.VoiceEffects;

namespace SingleEngine
{
    public class VoiceEngine : VoiceEngineBase
    {
        public override async Task<double[]> Play(VoiceConfig voicePreset, VoiceConfig subPreset, TalkScript talkScript, MasterEffectValue masterEffect, Action<int> setSamplingRate_Hz)
        {
            StateText = "再生されました。";
            if (IsPlaying) { return null; }
            IsPlaying = true;
            StopFlag = false;

            var wave = GetWave();

            IsPlaying = false;
            StopFlag = false;
            return wave;
        }

        private double[] GetWave()
        {
            Assembly assenbly = typeof(VoiceEngine).Assembly;
            // 引数は 名前空間 + ファイル名
            using var stream = assenbly.GetManifestResourceStream("SingleEngine.302.wav");
            using var reader = new WaveFileReader(stream);
            var wave = new List<double>();
            while (reader.Position < reader.Length)
            {
                var samples = reader.ReadNextSampleFrame();
                wave.Add(samples.First());
            }
            return wave.ToArray();
        }
    }
}
