﻿using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Helper
{
    public static class MusicPlayer
    {
        private static SoundPlayer sp = new SoundPlayer();

        public static void PlayHoverSound()
        {
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Assets\\Sounds\\button_hover.wav";
            sp.Play(); 
        }

        public static void PlayClickSound()
        {
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Assets\\Sounds\\button_click.wav";
            sp.Play();
        }
    }
}
