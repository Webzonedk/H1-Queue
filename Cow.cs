using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Queue
{
    public class Cow
    {
        #region Field

        private string name;
        private uint number;
        #endregion



        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public uint Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion



        #region Constructors
        public Cow()
        {

        }

        
        public Cow(string cowName, uint cowNumber)
        {
            this.name = cowName;
            this.number = cowNumber;
        }
        #endregion

       

    }

}
