using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Resourses
{
    public class Media
    {
        bool Iscurrent;

        public string SongName
        {
            get => SongName;
            set
            {
                SongName = value;
            }
        }
        public string SongUrl
        {
            get => SongUrl;
            set
            {
                SongUrl = value;
            }
        }
        public Media(string SongName,string SongUrl)
        {
            this.SongName = SongName;
            this.SongUrl = SongUrl;
        }

        public override bool Equals(object obj)
        {
            Media media = obj as Media;
            return media.SongName == this.SongName;
        }

        public override int GetHashCode()
        {
            return SongUrl.GetHashCode();
        }

    }
}
