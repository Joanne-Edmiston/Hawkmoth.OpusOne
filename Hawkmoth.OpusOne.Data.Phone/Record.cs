using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkmoth.OpusOne.Data.Phone
{
    public class Record
    {
        public Record(){}

        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
    }
}
