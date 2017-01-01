using System;

namespace Hawkmoth.OpusOne.UI.Phone
{
    public class MenuItem
    {
        public string Title { get; set; }

        public Type ClassType { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
