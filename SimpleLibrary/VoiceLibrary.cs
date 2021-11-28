using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yomiage.SDK;
using Yomiage.SDK.Config;
using Yomiage.SDK.Settings;

namespace SimpleLibrary
{
    public class VoiceLibrary : VoiceLibraryBase
    {

        public override object GetValue(string command, string key)
        {
            StateText = "呼び出されました。";
            Assembly assenbly = typeof(VoiceLibrary).Assembly;
            // 引数は 名前空間 + ファイル名
            using var stream = assenbly.GetManifestResourceStream("SimpleLibrary.302.wav");
            using var reader = new WaveFileReader(stream);
            var wave = new List<double>();
            while (reader.Position < reader.Length)
            {
                var samples = reader.ReadNextSampleFrame();
                wave.Add(samples.First());
            }
            return wave.ToArray();
        }

        public override bool TryGetValue<T>(string command, string key, out T value)
        {
            if (typeof(T) == typeof(double[]))
            {
                value = (T)GetValue(command, key);
                return true;
            }
            value = default(T);
            return false;
        }

    }
}
