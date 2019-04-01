using System;
using System.Collections.Generic;
using System.Text;
using System.Speech.Synthesis;
using SpeechLib;

namespace LED_RemotingServer
{
    /// <summary>
    /// ������
    /// </summary>
    public class SpeechCall
    {
        SpVoice speech = new SpVoice();
        int _yuying_sudu = -1;
        int _yuying_yingliang = 70;
        int _yuying_xuhao = 0;
        public SpeechCall()
        {
            speech = new SpVoice();
            if (TrasenClasses.GeneralClasses.Convertor.IsInteger(LED_Operate.yuying_xuhao))
            {

                int _yuying_xuhao1 = int.Parse(LED_Operate.yuying_xuhao);
                if (_yuying_xuhao1>=0)  _yuying_xuhao=_yuying_xuhao1;

            }
            if (TrasenClasses.GeneralClasses.Convertor.IsInteger(LED_Operate.yuying_sudu))
            {
                
                int _yuying_sudu1 = int.Parse(LED_Operate.yuying_sudu);
                if (_yuying_sudu1 >= -20) _yuying_sudu = _yuying_sudu1 - 1;//Ĭ��-1 �Ϳ�����

            }
            if (TrasenClasses.GeneralClasses.Convertor.IsInteger(LED_Operate.yuying_yingliang))
            {

                int _yuying_yingliang1 = int.Parse(LED_Operate.yuying_yingliang);
                if (_yuying_yingliang1 >= 0 && _yuying_yingliang<=120) _yuying_yingliang = _yuying_yingliang1;

            }
            speech.Voice = speech.GetVoices(string.Empty, string.Empty).Item(_yuying_xuhao);
            speech.Volume = _yuying_yingliang;
            speech.Rate = _yuying_sudu;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="callString"></param>
        public void SpeechCalling(string callString)
        {
            speech.WaitUntilDone(-1);
            //��ֹ��ǰ�ʶ�,�����
            //speech.Speak(" ", SpeechVoiceSpeakFlags.SVSFlagsAsync);

            //speech.Word += new _ISpeechVoiceEvents_WordEventHandler(speech_Word);

            speech.Speak(callString, SpeechVoiceSpeakFlags.SVSFlagsAsync);

        }
        public void CallStop()
        {
            speech.Speak("", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }


        //public SpeechCall()
        //{
        //    reader = new SpeechSynthesizer();
        //    //this.callString = callString;string callString
        //}

        //SpeechSynthesizer reader;
        ////private string callString;

        ///// <summary>
        ///// ����
        ///// </summary>
        ///// <param name="callString"></param>
        //public void SpeechCalling(string callString)
        //{
        //    if (reader != null)
        //    {
        //        while (reader.State == SynthesizerState.Speaking)
        //        {

        //        }
        //        reader.Dispose();
        //    }           
        //    reader = new SpeechSynthesizer();
        //    reader.Volume = 100;
        //    reader.Rate = 0;
        //    reader.SpeakAsync(callString);
        //}

        ///// <summary>
        ///// ��ͣ
        ///// </summary>
        //public void CallPause()
        //{
        //    if (reader != null)
        //    {
        //        if (reader.State == SynthesizerState.Speaking)
        //        {
        //            reader.Pause();
        //            //label2.Text = "PAUSED";
        //            //button3.Enabled = true;
        //        }
        //    }
        //}


        ///// <summary>
        ///// ֹͣ
        ///// </summary>
        //public void CallStop()
        //{
        //    if (reader != null)
        //    {
        //        reader.Dispose();
        //    }
        //}

        //public void CallResume()
        //{
        //    if (reader != null)
        //    {
        //        if (reader.State == SynthesizerState.Paused)
        //        {
        //            reader.Resume();
        //        }
        //    }
        //}
    }
}
