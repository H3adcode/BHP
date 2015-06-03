using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastHotkeyPlayer
{
    class BroadcastHotkeyPlayer
    {
        private BroadcastHotkeyPlayerWindow window;

        private SoundPlayer soundPlayer = new SoundPlayer();
        // private WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public BroadcastHotkeyPlayer(BroadcastHotkeyPlayerWindow window)
        {
            this.window = window; ;
            soundPlayer.LoadCompleted += new AsyncCompletedEventHandler(Player_LoadCompleted);
        }

        public void LoadSoundAsync(string param) 
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BroadcastHotkeyPlayer\\sounds\\" + param + ".wav";
            this.soundPlayer.SoundLocation = path;
            this.soundPlayer.LoadAsync();
        }

        void Player_LoadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            if (soundPlayer.IsLoadCompleted)
            {
                try
                {
                    this.soundPlayer.Play();
                }
                catch (Exception e)
                {
                    //TODO: error handling
                    throw;
                }
            }
        }
    }
}
